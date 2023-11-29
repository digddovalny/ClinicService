using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClinicServiceTests
{
    public class ClientControllerTests
    {

        private ClientController _clientController;
        private Mock<IClientRepository> _mockClientRepository;
        private const int _firstId = 1;

        public ClientControllerTests() 
        {
            _mockClientRepository = new Mock<IClientRepository>();
            _clientController = new ClientController(_mockClientRepository.Object);
        }

        [Fact]
        public void GetAllClientTest() 
        {
            // 1. Подготовка данных для тестирования

            List<Client> clientList = new List<Client>();
            clientList.Add(new Client());
            clientList.Add(new Client());
            clientList.Add(new Client());

            _mockClientRepository.Setup(repository => repository.GetAll()).Returns(clientList);

            // 2. Исполнение тестируемого метода

            var operationResult = _clientController.GetAll();

            // 3. Подготовка эталонного результата и проверк арезультата

            Assert.IsType<OkObjectResult>(operationResult.Result);

            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<List<Client>>(okObjectResult.Value);

            _mockClientRepository.Verify(repository => repository.GetAll(), Times.AtLeastOnce);
        }

        public static object[][] CorrectCreateClientData =
        {
            new object[] {new DateTime(1986, 1, 22), "pas1", "Васильев1", "Вася1", "Васильевич1" },
            new object[] {new DateTime(1986, 1, 22), "pas2", "Васильев2", "Вася2", "Васильевич2" },
            new object[] {new DateTime(1986, 1, 22), "pas3", "Васильев3", "Вася3", "Васильевич3" },
            new object[] {new DateTime(1986, 1, 22), "pas4", "Васильев4", "Вася4", "Васильевич4" },
            new object[] {new DateTime(1986, 1, 22), "pas5", "Васильев5", "Вася5", "Васильевич5" },
        };

        [Theory]
        [MemberData(nameof(CorrectCreateClientData))]
        public void CreateClientTest(DateTime birthDay, string document, string surName, string firstName, string patronymic) 
        {
            // 1. Подготовка данных для тестирования

            CreateClientRequest createClientRequest = new CreateClientRequest();
            createClientRequest.BirthDay = birthDay;
            createClientRequest.Document = document;
            createClientRequest.SurName = surName;
            createClientRequest.FirstName = firstName;
            createClientRequest.Patronymic = patronymic;

            //var createClientRequest = new CreateClientRequest();
            //createClientRequest.FirstName = "Вася";
            //createClientRequest.SurName = "Васильев";
            //createClientRequest.Patronymic = "Васильевич";
            //createClientRequest.BirthDay = DateTime.Now.AddYears(-33);
            //createClientRequest.Document = "pas";

            _mockClientRepository.Setup(repository => repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();
            // 2. Исполнение тестируемого метода

            var operationResult = _clientController.Create(createClientRequest);

            // 3. Подготовка эталонного результата и проверк арезультата

            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockClientRepository.Verify(repository => repository.Create(It.IsNotNull<Client>()), Times.AtLeastOnce());
        }

        [Fact]
        public void UpdateClientTest() 
        {
            const string newName = "NewName";

            UpdateClientRequest updateClientRequest = new UpdateClientRequest();
            updateClientRequest.ClientId = 1;
            updateClientRequest.Document = "pass";
            updateClientRequest.SurName = "Иванов";
            updateClientRequest.FirstName = "Иван";
            updateClientRequest.Patronymic = "Иванович";
            updateClientRequest.BirthDay = new DateTime(2000, 1, 23);

            updateClientRequest.FirstName = newName;

            _mockClientRepository.Setup(repository => repository.Update(It.IsNotNull<Client>())).Returns(1).Verifiable();

            var operationResult = _clientController.Update(updateClientRequest);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockClientRepository.Verify(repository => repository.Update(It.IsNotNull<Client>()), Times.AtLeastOnce());

            Assert.Equal(newName, updateClientRequest.FirstName);
        }

        [Fact]
        public void DeleteClientTest() 
        {
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client());
            clientList.Add(new Client());
            clientList.Add(new Client());

            var client = clientList.First();
            var count = clientList.Count();

            _mockClientRepository.Setup(repository => repository.Delete(It.IsNotNull<int>())).Returns(1);

            var operationResult = _clientController.Delete(client.ClientId);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockClientRepository.Verify(repository => repository.Delete(It.IsNotNull<int>()), Times.AtLeastOnce());

            Assert.True(clientList.Count == count);
        }

        [Fact]
        public void GetByIdClientTest() 
        {
            List<Client> clients = new List<Client>();


            for (int i = 1; i < 5; i++)
            {
                Client client = new Client();
                
                client.ClientId = i;
                client.SurName = $"Васильев{i}";
                client.FirstName = $"Вася{i}";
                client.Patronymic = $"Васильевич{i}";
                client.Document = $"pass{i}";
                client.BirthDay = new DateTime(2000, 1, i);

                clients.Add(client);
            }

            _mockClientRepository.Setup(repository => repository.GetById(_firstId)).Returns(clients.ElementAt(0));

            var operationResult = _clientController.GetById(_firstId);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<Client>(okObjectResult.Value);
            _mockClientRepository.Verify(repository => repository.GetById(It.IsNotNull<int>()), Times.AtLeastOnce());

            Assert.Equal(_firstId, clients.ElementAt(0).ClientId);
        }
    }
}
