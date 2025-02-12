using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBaseService
    {
        public BaseModel GetAllModels();

        public BaseModel GetModelById(int id);

        public BaseModel CreateModel();

        public bool UpdateModel(BaseModel model);

        public bool DeleteModel(BaseModel model);
    }
}
