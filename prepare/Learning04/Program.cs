using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment asignacion = new MathAssignment();
        asignacion.setName("Roberto Rodriguez");
        asignacion.setTopic("Multiplication");
        asignacion.Setterz("7.3", "8-19");
        asignacion.GetHomeworkList();

        Console.WriteLine();

        WritingAssignment asignacionDos = new WritingAssignment();
        asignacionDos.setName("Mary Waters");
        asignacionDos.setTopic("European History");
        asignacionDos.SetUp("The Causes of World War II");
        asignacionDos.GetHomeworkList();
    }
}