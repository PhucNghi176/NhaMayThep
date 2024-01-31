using Humanizer;
using MediatR;
﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.HoaDonCongTacNhanVien;
using NhaMayThep.Application.HoaDonCongTacNhanVien.Create;
using NhaMayThep.Application.HoaDonCongTacNhanVien.DowloadFile;
using NhaMayThep.Application.HoaDonCongTacNhanVien.GetAll;
using NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiHoaDon;
using NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdNguoiTao;
using NhaMayThep.Application.HoaDonCongTacNhanVien.GetByPagination;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Api.Controllers
{
   
    [ApiController]
    [Authorize]
    public class HoaDonCongTacNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;
        public HoaDonCongTacNhanVienController(ISender sender)
        {
            _mediator = sender;
        }

      

        //private  async Task<string> WriteFile(IFormFile file)
        //{
        //    string filename = "";
        //    try
        //    {
        //        var extesion = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1 ];
        //        filename =  DateTime.Now.Ticks.ToString() + extesion;
        //        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile\\File");

        //        if (!Directory.Exists(filepath))
        //        {
        //            Directory.CreateDirectory(filepath);
        //        }
        //        var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile\\File", filename);
        //        using (var stream = new FileStream(exactpath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }
        //        return filename;
        //    }
        //    catch (Exception ex) 
        //    {
        //        return filename;
        //    }
        //}

        //private async Task<string> WriteFile(IFormFile file, string userEnteredFileName)
        //{
        //    try
        //    {
        //        // Lấy phần mở rộng (extension) từ tên file gốc nếu có
        //        string extension = Path.GetExtension(file.FileName);

        //        // Lấy ngày và tháng từ thời điểm hiện tại
        //        string currentDate = DateTime.Now.ToString("yyyyMMdd");

        //        // Tạo tên file mới bao gồm tên người dùng nhập, ngày và thời điểm hiện tại
        //        string filename = $"{userEnteredFileName}_{currentDate}{extension}";

        //        // Đường dẫn đến thư mục lưu trữ tệp tin
        //        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile\\File");

        //        // Kiểm tra xem thư mục lưu trữ có tồn tại hay không, nếu không thì tạo mới
        //        if (!Directory.Exists(directoryPath))
        //        {
        //            Directory.CreateDirectory(directoryPath);
        //        }

        //        // Tạo đường dẫn đầy đủ đến tệp tin
        //        string filePath = Path.Combine(directoryPath, filename);

        //        // Lưu tệp tin vào đường dẫn đã tạo
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //        // Trả về đường dẫn của tệp tin đã được sửa tên
        //        return filePath;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý lỗi nếu có
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return null;
        //    }
        //}

        [HttpPost("hoa-don-cong-tac-nhan-vien/uploadFile")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UploadFile(
            IFormFile file, string fileNameByUser,  string lichSuCongTacID, int loaiHoaDonID,
            CancellationToken cancellationToken = default)
        {
            CreateHoaDonCongTacNhanVienCommand command = new CreateHoaDonCongTacNhanVienCommand() { 
                LichSuCongTacID = lichSuCongTacID ,
                LoaiHoaDonID = loaiHoaDonID,
                formFile = file,
                NameForFile = fileNameByUser,
            };            
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("hoa-don-cong-tac-nhan-vien/dowloadFile")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DowloadFile(string filename, CancellationToken cancellationToken = default)
        {
            var query = new DowloadHoaDonCongTacNhanVienQuery(filename);
            var result = await _mediator.Send(query, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return result;
        }


        [HttpGet("hoa-don-cong-tac-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllHoaDonCongTacNhanVienQuery(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<HoaDonCongTacNhanVienDto>>(result));
        }

        [HttpGet("hoa-don-cong-tac-nhan-vien/{idNguoiTao}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByNguoiTao([FromRoute] string idNguoiTao ,CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdNguoiTaoQuery(idNguoiTao), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<HoaDonCongTacNhanVienDto>>(result));
        }

        [HttpGet("hoa-don-cong-tac-nhan-vien/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<HoaDonCongTacNhanVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<HoaDonCongTacNhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<HoaDonCongTacNhanVienDto>>>> GetPagination([FromQuery] GetHoaDonCongTacNhanVienByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("hoa-don-cong-tac-nhan-vien/{idLoaiHoaDon}/{year}/{month}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByLoaiHoaDon(
            [FromRoute] int idLoaiHoaDon,
            [FromRoute] int year,
            [FromRoute] int month,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdLoaiHoaDonQuery(idLoaiHoaDon,year,month), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<HoaDonCongTacNhanVienDto>>(result));
        }
    }
}
