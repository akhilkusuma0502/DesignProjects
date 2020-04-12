using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_Entities
{
   public class Document_Type_Details
    {

        private int _documentTypeId;

        public int DocumentTypeId
        {
            get { return _documentTypeId; }
            set { _documentTypeId = value; }
        }
        private string _documentTypeName;

        public string DocumentTypeName
        {
            get { return _documentTypeName; }
            set { _documentTypeName = value; }
        }
        public Document_Type_Details()
        {

        }

        public Document_Type_Details(int DocumentTypeId, string DocumentTypeName)
        {
            this.DocumentTypeId = DocumentTypeId;
            this.DocumentTypeName = DocumentTypeName;
        }
    }
}
