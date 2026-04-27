namespace UCSS.Core
{
    /* Aceasta clasa gestioneaza logica de verificare a suprapunerilor in orar */
    public class ScheduleManager
    {
        /* Functie care verifica daca un profesor este deja ocupat intr-un anumit interval */
        public bool DetectTeacherConflict(int teacherId, string day, int timeSlot)
        {
            /* Initializarea obligatorie a variabilelor cu o valoare de pornire */
            bool hasConflict = false;

            /* Regula 1: Acolade obligatorii la IF, chiar si pentru o singura linie */
            /* Regula 5: Este interzisa folosirea comenzii switch, folosim if-else */
            if (teacherId == 0)
            {
                hasConflict = false;
            }
            else
            {
                /* Simulam o verificare: daca profesorul are curs lunea la ora 8 */
                if (day == "Monday" && timeSlot == 8)
                {
                    hasConflict = true;
                }
                else
                {
                    hasConflict = false;
                }
            }

            return hasConflict;
        }
    }
}