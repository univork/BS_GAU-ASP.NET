using PMEntity;
using PMRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webapi.Controllers
{
    public class ClothController : ApiController
    {
        private ClothRepository repo = new ClothRepository();

        public List<Cloth> Get()
        {
            return repo.GetAll();
        }
        public Cloth Get(int id)
        {

            return repo.Get(id);
        }
        
        public bool Post(Cloth cloth)
        {
            return repo.Insert(cloth);
        }

        public bool Put(Cloth cloth, bool warning)
        {
            return repo.Update(cloth, warning);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
