using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.File;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileService _fileService;
        public CarImagesManager(ICarImagesDal carImagesDal, IFileService fileService)
        {
            _carImagesDal = carImagesDal;
            _fileService = fileService;
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = _fileService.Upload(file, PathConstants.CarImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult("fotoğraf eklendi");
        }

        public IResult Delete(CarImages carImages)
        {
            _fileService.Delete(PathConstants.CarImagesPath + carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult("araba resmi silindi");
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), "tüm araçlar listelendi");
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == id), "Id göre foto listelendi");
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int Id)
        {
            var result = _carImagesDal.GetAll(i => i.CarId == Id).Count;
            if (result > 0)
            {
                return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == Id), "id göre araç getirildi");

            }
            return new SuccessDataResult<List<CarImages>>(GetDefaultImage(Id).Data, "default fotoğraf getirildi");
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = _fileService.Update(file, PathConstants.CarImagesPath + carImages.ImagePath,
                PathConstants.CarImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult("fotoğraf güncellendi");
        }

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("en fazla 5 tane fotoğraf ekleyebilirsin");
            }
            return new SuccessResult();

        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImages = new List<CarImages>();

            carImages.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = @"default.jpg" });

            return new SuccessDataResult<List<CarImages>>(carImages);
        }
    }
}
