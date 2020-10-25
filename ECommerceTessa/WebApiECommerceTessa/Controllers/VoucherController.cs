using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Voucher;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherController(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetVoucherById(long id)
        {
            try
            {
                var voucherId = await _voucherRepository.GetById(id);

                return Ok(voucherId);
            }
            catch (Exception e)
            {
                return NotFound("The Voucher was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllVouchers()
        {
            try
            {
                var allVoucher = await _voucherRepository.GetAll();

                return Ok(allVoucher);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [EnableCors("_myPoliticy")]
        [Route("create")]
        public async Task<IActionResult> CreateVoucher(VoucherCreationDto dto)
        {
            var newVoucher = new VoucherCreationDto
            {
                Number = dto.Number,
                Date = dto.Date,
                SubTotal = dto.SubTotal,
                Discount = dto.Discount,
                Total = dto.Total,
                WayToPay = dto.WayToPay,
                UserId = dto.UserId
            };

            await _voucherRepository.Create(newVoucher);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPoliticy")]
        [Route("update")]
        public async Task<IActionResult> UpdateVoucher(VoucherCreationDto dto)
        {
            try
            {
                var update = new VoucherCreationDto
                {
                    Number = dto.Number,
                    Date = dto.Date,
                    SubTotal = dto.SubTotal,
                    Discount = dto.Discount,
                    Total = dto.Total,
                    WayToPay = dto.WayToPay,
                    UserId = dto.UserId
                };

                await _voucherRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Voucher cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPoliticy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteVoucher(VoucherCreationDto dto)
        {
            try
            {
                await _voucherRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Voucher cannot be delete");
            }
        }
    }
}
