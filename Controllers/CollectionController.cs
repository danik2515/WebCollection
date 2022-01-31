using Microsoft.AspNetCore.Mvc;
using WebCollection.Models.Interface;
using WebCollection.Models;
using WebCollection.Models.ViewModels;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;

namespace WebCollection.Controllers {
    public class CollectionController : Controller {

        private readonly ICollection _collection;
        private readonly Cloudinary _cloudinary;
        private readonly ITheme _theme;
        private readonly IItem _item;
        public IConfiguration AppConfiguration { get; set; }

        public CollectionController(ICollection collection,ITheme theme,IItem item) {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            AppConfiguration = builder.Build();
            Account account = new Account(
                AppConfiguration["cloudinary:CloudName"],
                AppConfiguration["cloudinary:APIKey"],
                AppConfiguration["cloudinary:APISecret"]);
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
            _collection = collection;
            _theme = theme;
            _item = item;
        }
        [Authorize]
        public ViewResult Create() {

                return View(new CollcetionCreateViewModel { ITheme = _theme, IItem = _item });

        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CollcetionCreateViewModel collectionView,string currentUserId) {
            Collection collection = new Collection { Name = collectionView.Name, Description = collectionView.Description, ThemeId=collectionView.ThemeId };
            if (collection.Description == null) { collection.Description = ""; }
            try {
                IFormFile uploadImage = collectionView.IFormFile;
                ImageUploadParams uploadParams = new ImageUploadParams() {
                    File = new FileDescription(uploadImage.FileName, uploadImage.OpenReadStream()),
                };
                ImageUploadResult uploadResult = _cloudinary.Upload(uploadParams);
                collection.ImageId = uploadResult.PublicId;
            }
            catch { collection.ImageId = "Default_xedqh1"; }
            collection.UserId = currentUserId;
            _collection.SaveCollection(collection);
            if (collectionView.NameFields != null) {
                for (int i=0;i< collectionView.NameFields.Count();i++) {
                    _item.SaveField(new CollectionField { Name = collectionView.NameFields[i], FieldTypeId = _item.GetTypeId(collectionView.TypeFields[i]), CollectionId = _collection.GetCollectionId(collection.Name) });
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
