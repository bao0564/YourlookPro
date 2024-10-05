﻿
namespace yourlook.MenuKid
{
	public interface IUploadPhoto
	{
		Task<string> uploadOnePhotosAsync(IFormFile files, string folder);
		Task<List<string>> uploadPhotosAsync(List<IFormFile> files,string folder);
	}
	public class UploadPhoto: IUploadPhoto
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public UploadPhoto (IWebHostEnvironment webHostEnvironment)   
		{
			_webHostEnvironment = webHostEnvironment;
		}
		//tải nhiều ảnh
		public async Task<List<string>> uploadPhotosAsync(List<IFormFile> files, string folder)
		{
			var filePaths = new List<string>();

			foreach (var file in files)
			{
				if (file.Length > 0)
				{
					string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, folder);
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string filePath = Path.Combine(uploadDir, fileName);

					// Tạo thư mục nếu chưa tồn tại
					if (!Directory.Exists(uploadDir))
					{
						Directory.CreateDirectory(uploadDir);
					}

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}

					filePaths.Add(/*"/img/"+*/ fileName);
				}
			}

			return filePaths;
		}
		//tải 1 ảnh
		public async Task<string> uploadOnePhotosAsync(IFormFile file, string folder)
		{

			string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, folder);
			string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			string filePath = Path.Combine(uploadDir, fileName);

			// Tạo thư mục nếu chưa tồn tại
			if (!Directory.Exists(uploadDir))
			{
				Directory.CreateDirectory(uploadDir);
			}

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return /*"/img/" +*/ fileName;
		}
	}
}
