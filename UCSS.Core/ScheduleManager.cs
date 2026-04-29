using UCSS.Data;
namespace UCSS.Core 
    
     {
    /* Aceasta clasa gestioneaza logica de verificare a suprapunerilor in orar */
    public class ScheduleManager
    {
        /* Functie care verifica daca un profesor este deja ocupat intr-un anumit interval */
        public bool DetectTeacherConflict(int teacherId, string day, int startTime, int endTime, List<Schedule> existingSchedules)
        {
            // Presupunem că nu avem conflict la început
            bool hasConflict = false;

            foreach (var existing in existingSchedules)
            {
                // Verificăm dacă e același profesor în aceeași zi
                if (existing.TeacherId == teacherId && existing.Day == day)
                {
                    // Verificăm dacă orele se suprapun
                    // Regula: (Start1 < End2) ȘI (End1 > Start2)
                    if (startTime < existing.EndTime && endTime > existing.StartTime)
                    {
                        hasConflict = true;
                        break; // Am găsit un conflict, ne oprim
                    }
                }
            }

            return hasConflict;
        }
        
    }
}