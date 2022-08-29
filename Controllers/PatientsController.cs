using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadClinicWebApplication2022.Models;
using QuadClinicWebApplication2022.Repository;

namespace QuadClinicWebApplication2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IReceptionistRepository _repository;

        public PatientsController(IReceptionistRepository context)
        {
            _repository = context;
        }

        #region Get all patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _repository.GetPatient();
        }
        #endregion

        #region Insert new patient
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatientRecord([FromBody] Patient patient)
        {
            //insert a record and return as an object named employee
            if (ModelState.IsValid)
            {
                var newPatient = await _repository.PostPatientRecord(patient);

                if (newPatient != null)
                {
                    return newPatient;
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
        public async Task<ActionResult<Patient>> PutPatient(Patient patient)
        {
            //update  a record and return as an object named employee
            if (ModelState.IsValid)
            {
                var newPatientId = await _repository.PutPatient(patient);

                if (newPatientId != null)
                {
                    return newPatientId;
                }
                else
                {
                    return NotFound();
                }
            }
            return patient;
        }
        #endregion

        #region List only Active patients
        [HttpGet]
        [Route("active")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetActivePatients()
        {

            var patient = await _repository.GetActivePatients();
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }
        #endregion

        #region List only InActive patients
        [HttpGet]
        [Route("inactive")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetInActivePatients()
        {

            var patient = await _repository.GetInActivePatients();
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }
        #endregion

        #region Search by RegId
        [HttpGet("{regId}")]
        public async Task<ActionResult<Patient>> GetPatientByRegId(string regId)
        {
            var patient = await _repository.GetPatientByRegId(regId);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }
        #endregion
    }
}
