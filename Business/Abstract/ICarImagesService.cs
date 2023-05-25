using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
        IDataResult<List<CarImages>> GetImagesByCarId(int Id);
        IResult Add(IFormFile file, CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
    }
}
