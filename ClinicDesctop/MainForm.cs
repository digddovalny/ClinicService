using ClinicServiceNamespace;
using System.Globalization;

namespace ClinicDesctop
{
    public partial class MainForm : Form
    {

        const string FMT = "O";

        public MainForm()
        {
            InitializeComponent();
        }

        private void listViewClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLoadClients_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();

            listViewClients.Items.Clear();

            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                //listViewClients.Items.Add(item);

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Text = client.SurName;
                item.SubItems.Add(subItem1);

                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                subItem2.Text = client.FirstName;
                item.SubItems.Add(subItem2);

                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                subItem3.Text = client.Patronymic;
                item.SubItems.Add(subItem3);

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                subItem4.Text = client.Document;
                item.SubItems.Add(subItem4);

                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                subItem5.Text = client.BirthDay.ToString();
                item.SubItems.Add(subItem5);

                listViewClients.Items.Add(item);
            }
        }

        private void DeleteClient_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            foreach (ListViewItem eachItem in listViewClients.SelectedItems)
            {
                listViewClients.Items.Remove(eachItem);
                int id = Convert.ToInt32(eachItem.Text);

                clinicClient.DeleteAsync(id);
                MessageBox.Show($"Запись удалена c id {id}");
            }
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtSurName.Text) || string.IsNullOrEmpty(txtName.Text)
                || string.IsNullOrEmpty(txtPatronymic.Text) || string.IsNullOrEmpty(txtDocum.Text) || string.IsNullOrEmpty(txtBirthday.Text))
            {
                return;
            }

            ListViewItem item = new ListViewItem(txtId.Text);
            item.SubItems.Add(txtSurName.Text);
            item.SubItems.Add(txtName.Text);
            item.SubItems.Add(txtPatronymic.Text);
            item.SubItems.Add(txtDocum.Text);

            listViewClients.Items.Add(item);

            var dbObject = new CreateClientRequest();
            dbObject.SurName = txtSurName.Text;
            dbObject.FirstName = txtName.Text;
            dbObject.Patronymic = txtPatronymic.Text;
            dbObject.Document = txtDocum.Text;
            dbObject.BirthDay = Convert.ToDateTime(txtBirthday.Text);

            clinicClient.CreateAsync(dbObject);

            txtId.Clear();
            txtSurName.Clear();
            txtName.Clear();
            txtPatronymic.Clear();
            txtDocum.Clear();
            txtBirthday.Clear();

            txtId.Focus();
        }

        private void UpdateClient_Click(object sender, EventArgs e)
        {


            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            if (string.IsNullOrEmpty(txtUpdateSurName.Text) || string.IsNullOrEmpty(txtUpdateName.Text)
                || string.IsNullOrEmpty(txtUpdatePatronymic.Text) || string.IsNullOrEmpty(txtUpdateDoc.Text) || string.IsNullOrEmpty(txtupdateBrd.Text))
            {
                return;
            }

            foreach (ListViewItem eachItem in listViewClients.SelectedItems)
            {
                int id = Convert.ToInt32(eachItem.Text);
                var dbObject = new UpdateClientRequest();
                dbObject.ClientId = id;
                dbObject.SurName = txtUpdateSurName.Text;
                dbObject.FirstName = txtUpdateName.Text;
                dbObject.Patronymic = txtUpdatePatronymic.Text;
                dbObject.Document = txtUpdateDoc.Text;
                dbObject.BirthDay = Convert.ToDateTime(txtupdateBrd.Text);

                clinicClient.EditAsync(dbObject);

                MessageBox.Show($"Запись успешно обновлена c id {id}");
            }

            txtSurName.Clear();
            txtName.Clear();
            txtPatronymic.Clear();
            txtDocum.Clear();
            txtBirthday.Clear();

        }

        private void GetClientById_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            int clientId = Convert.ToInt32(txtGetClientById.Text);

            Client client = clinicClient.GetAsync(clientId).Result;

            listViewClients.Items.Clear();

            if (!string.IsNullOrEmpty(txtGetClientById.Text))
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                //listViewClients.Items.Add(item);

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Text = client.SurName;
                item.SubItems.Add(subItem1);

                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                subItem2.Text = client.FirstName;
                item.SubItems.Add(subItem2);

                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                subItem3.Text = client.Patronymic;
                item.SubItems.Add(subItem3);

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                subItem4.Text = client.Document;
                item.SubItems.Add(subItem4);

                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                subItem5.Text = client.BirthDay.ToString();
                item.SubItems.Add(subItem5);

                listViewClients.Items.Add(item);

            }
        }
    }
}