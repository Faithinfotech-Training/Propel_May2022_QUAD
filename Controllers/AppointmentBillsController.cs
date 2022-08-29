using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadClinicWebApplication2022.Models;
using QuadClinicWebApplication2022.Repository;
using QuadClinicWebApplication2022.ViewModel;

namespace QuadClinicWebApplication2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentBillsController : ControllerBase
    {
        private readonly IReceptionistRepository _repository;

        public AppointmentBillsController(IReceptionistRepository context)
        {
            _repository = context;
        }

        #region Get all AppointmentBill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentBill>>> GetAllAppointmentBill()
        {
            return await _repository.GetAllAppointmentBill();
        }
        #endregion

        #region Create new AppointmentBill
        [HttpPost]
        public async Task<ActionResult<AppointmentBill>> PostAppointmentBillRecord([FromBody] AppointmentBill appointmentBill)
        {
            //insert a record and return
            if (ModelState.IsValid)
            {
                var newAppointmentBill = await _repository.PostAppointmentBillRecord(appointmentBill);

                if (newAppointmentBill != null)
                {
                    return newAppointmentBill;
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Edit/Update
        [HttpPut]
        public async Task<ActionResult<AppointmentBill>> PutAppointmentBill(AppointmentBill appointmentBill)
        {
            //update a record and return
            if (ModelState.IsValid)
            {
                var newAppointmentBill = await _repository.PutAppointmentBill(appointmentBill);

                if (newAppointmentBill != null)
                {
                    return newAppointmentBill;
                }
                else
                {
                    return NotFound();
                }
            }
            return appointmentBill;
        }
        #endregion

        #region Generate Appointment Bill
        [HttpGet]
        [Route("billgenerate")]
        public async Task<ActionResult<IEnumerable<AppointmentBillViewModel>>> AppointmentBillGenerate()
        {
            return await _repository.AppointmentBillGenerate();
        }
        #endregion

    }
}
