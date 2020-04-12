using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_Entities
{
   public class Document_Details
    {

        private int _documentId;

        public int DocumentId
        {
            get { return _documentId; }
            set { _documentId = value; }
        }

        private string _documentName;

        public string DocumentName
        {
            get { return _documentName; }
            set { _documentName = value; }
        }

        private string _documentDescription;

        public string DocumentDescription
        {
            get { return _documentDescription; }
            set { _documentDescription = value; }
        }
        private string _documentPath;

        public string DocumentPath
        {
            get { return _documentPath; }
            set { _documentPath = value; }
        }
        private Document_Type_Details _documentTypeId;

        public Document_Type_Details DocumentTypeId
        {
            get { return _documentTypeId; }
            set { _documentTypeId = value; }
        }


        private Disciplines _disciplineId;

        public Disciplines DisciplineId
        {
            get { return _disciplineId; }
            set { _disciplineId = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        private DateTime _uploadDate;

        public DateTime UploadDate
        {
            get { return _uploadDate; }
            set { _uploadDate = value; }
        }
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string DocumentTypeName { get; set; }
        public string DisciplineName { get; set; }

        public Document_Details()
        {
            DocumentTypeId = new Document_Type_Details();
            DisciplineId = new Disciplines();
        }

    }
}
