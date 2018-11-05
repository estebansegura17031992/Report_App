using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reporter_app.Models
{
    public class ClientData
    {
        private string ConnectionString = string.Empty;

        public ClientData()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["dbReporterAppConnectionString"].ConnectionString;
        }

        public int InsertClient(Client client)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("INSERT INTO Client (nameClient, lastNameClient ,accountNumberClient, accountTypeClient) Values('{0}', '{1}', '{2}', {3} );"
            + "SELECT @@Identity", client.nameClient, client.lastNameClient, client.accountNumberClient, client.accountTypeClient);

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Execute the command to SQL Server and return the newly created ID
            int newClientID = Convert.ToInt32((decimal)command.ExecuteScalar());

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            return newClientID;
        }

        public int SaveClient(Client client)
        {

            //Create the SQL Query for inserting an article
            string createQuery = String.Format("INSERT INTO Client (nameClient, lastNameClient ,accountNumberClient, accountTypeClient) Values('{0}', '{1}', '{2}', {3} );"
                + "SELECT @@Identity", client.nameClient, client.lastNameClient, client.accountNumberClient, client.accountTypeClient);

            //Create the SQL Query for updating an article
            string updateQuery = String.Format("UPDATE Client SET nameClient='{0}', lastNameClient = '{1}', accountNumberClient ='{2}', accountTypeClient = {3} WHERE Id = {4};",
                client.nameClient, client.lastNameClient, client.accountNumberClient, client.accountTypeClient,client.Id);

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (client.Id != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedClientID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedClientID = Convert.ToInt32(commandResult);
                }
                else
                {
                    //the update SQL query will not return the primary key but if doesn't throw exception
                    //then we will take it from the already provided data
                    savedClientID = client.Id;
                }
            }
            catch (Exception ex)
            {
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedClientID;
        }



        public Client GetClientById(int clientId)
        {
            Client result = new Client();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("SELECT * FROM Client where Id={0}", clientId);

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Id = Convert.ToInt32(dataReader["Id"]);
                    result.nameClient = dataReader["nameClient"].ToString();
                    result.lastNameClient = dataReader["lastNameClient"].ToString();
                    result.accountNumberClient = Convert.ToInt32(dataReader["accountClient"]);
                    result.accountTypeClient = Convert.ToInt32(dataReader["accountTypeClient"]);
                }
            }

            return result;
        }

        public List<Client> GetClients()
        {
 
            List<Client> result = new List<Client>();
 
            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("SELECT * FROM Client");

        //Create and open a connection to SQL Server
        SqlConnection connection = new SqlConnection(ConnectionString);
        connection.Open();
 
            SqlCommand command = new SqlCommand(sqlQuery, connection);

        //Create DataReader for storing the returning table into server memory
        SqlDataReader dataReader = command.ExecuteReader();

        Client client = null;
 
            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    client = new Client();

                    client.Id = Convert.ToInt32(dataReader["Id"]);
                    client.nameClient = dataReader["nameClient"].ToString();
                    client.lastNameClient = dataReader["lastNameClient"].ToString();
                    client.accountNumberClient = Convert.ToInt32(dataReader["accountNumberClient"]);
                    client.accountTypeClient = Convert.ToInt32(dataReader["accountTypeClient"]);

                    result.Add(client);
                }
            }
 
            return result;
 
        }
 
 
        public bool DeleteClient(int clientId)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("DELETE FROM Client WHERE Id = {0}", clientId);

            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
            result = true;
            
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }
    }
}