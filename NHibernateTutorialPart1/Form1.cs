using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernateCRUD;

namespace NHibernateCRUD
{
    public partial class Form1 : Form
    {
        private Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConfiguration = new Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            // Add Record
            using (mySession.BeginTransaction())
            {
                Contact loContact = new Contact { FirstName = "Ali", LastName = "Kaya" };
                mySession.Save(loContact);
              

                mySession.Transaction.Commit();
            }

            // List Contact

            using (mySession.BeginTransaction())
            {
                ICriteria criteria = mySession.CreateCriteria<Contact>();
                IList<Contact> list = criteria.List<Contact>();

                mySession.Transaction.Commit();
            }



            // Delete Contact

            using (mySession.BeginTransaction())
            {

                var item= mySession.Get<Contact>(2);
                mySession.Delete(item);

                mySession.Transaction.Commit();
            }

        }
    }
}
