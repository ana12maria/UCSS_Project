using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// Aici aducem celelalte proiecte ca să nu mai primim erori:
using UCSS.Data;
using UCSS.Core;

namespace UCSS.Web.Controllers // (Dacă la tine namespace-ul are alt nume, lasă-l pe al tău)
{
    public class HomeController : Controller
    {
        // 1. "Angajăm" Creierul (Managerul) ca să îl putem folosi mai jos!
        private ScheduleManager _scheduleManager = new ScheduleManager();

        // 2. Asta e pagina principală
        public IActionResult Index()
        {
            return View();
        }

        // 3. Asta e funcția noastră nouă pentru butonul de Salvare
        [HttpPost]
        public IActionResult AdaugaOrar(int teacherId, int roomId, string subject, string groupName, string day, int startTime, int endTime)
        {
            // Creăm o listă goală deocamdată (până ne legăm la baza de date reală)
            var orarExistent = new List<Schedule>();

            // Verificăm conflictele:
            if (_scheduleManager.DetectTeacherConflict(teacherId, day, startTime, endTime, orarExistent))
                return BadRequest("Eroare: Profesorul are deja un curs!");

            if (_scheduleManager.DetectRoomConflict(roomId, day, startTime, endTime, orarExistent))
                return BadRequest("Eroare: Sala este ocupată!");

            if (_scheduleManager.DetectGroupConflict(groupName, day, startTime, endTime, orarExistent))
                return BadRequest("Eroare: Grupa are deja curs!");

            // Dacă trece de toate IF-urile, e de bine!
            return Ok("Succes! Orarul a fost salvat fără conflicte.");
        }
    }
}