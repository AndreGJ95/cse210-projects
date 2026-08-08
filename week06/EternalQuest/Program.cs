using System;
/*
1. Se implemento un sistema de niveles:
   - Rastrea el progreso del jugador según la puntuación (1 nivel por cada 1.000 puntos obtenidos).
   - Asigna títulos de nivel personalizados (p. ej., Buscador Novato, Explorador Aprendiz, Campeón Maestro).

2. Incorporación de objetivos negativos ("BadHabitGoal"):
   - Se introdujo una clase derivada personalizada, `BadHabitGoal`, que hereda de `Goal`.
   - Permite a los usuarios registrar malos hábitos que restan puntos al producirse, añadiendo una dinámica de riesgo/recompensa a la gamificación de las misiones.

3. Se hizo una validación robusta de entradas y gestión de E/S de archivos:
   - Se gestionó de forma segura la verificación de archivos inexistentes y se procesó la restauración limpia de estados completos de objetos en memoria.

*/
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}