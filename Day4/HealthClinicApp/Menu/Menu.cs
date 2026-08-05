using HealthClinicApp.Service;

namespace HealthClinicApp.Menu;

public class Menu
{
    DoctorService doctorService = new DoctorService();
    PatientService patientService = new PatientService();
    AppointmentService appointmentService = new AppointmentService();
    RoomService roomService = new RoomService();
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================================");
            Console.WriteLine("      HEALTH CLINIC MANAGEMENT");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Doctor Management");
            Console.WriteLine("2. Patient Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("4. Room Management");
            Console.WriteLine("0. Exit");

            Console.Write("\nEnter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DoctorMenu();
                    break;

                case 2:
                    PatientMenu();
                    break;

                case 3:
                    AppointmentMenu();
                    break;

                case 4:
                    RoomMenu();
                    break;

                case 0:
                    Console.WriteLine("\nThank you for using Health Clinic Management System.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nInvalid Choice!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void DoctorMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("========== DOCTOR MANAGEMENT ==========");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View Doctors");
            Console.WriteLine("3. Update Doctor");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("0. Back");

            Console.Write("\nEnter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    doctorService.AddDoctor();
                    break;

                case 2:
                    doctorService.ViewDoctors();
                    break;

                case 3:
                    doctorService.UpdateDoctor();
                    break;

                case 4:
                    doctorService.DeleteDoctor();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("\nInvalid Choice!");
                    break;
            }

            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
    }

    private void PatientMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("========== PATIENT MANAGEMENT ==========");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View Patients");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("0. Back");

            Console.Write("\nEnter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    patientService.AddPatient();
                    break;

                case 2:
                    patientService.ViewPatients();
                    break;

                case 3:
                    patientService.UpdatePatient();
                    break;

                case 4:
                    patientService.DeletePatient();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("\nInvalid Choice!");
                    break;
            }

            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
    }

    private void AppointmentMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("======= APPOINTMENT MANAGEMENT =======");
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("3. Update Appointment");
            Console.WriteLine("4. Delete Appointment");
            Console.WriteLine("0. Back");

            Console.Write("\nEnter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    appointmentService.AddAppointment();
                    break;

                case 2:
                    appointmentService.ViewAppointments();
                    break;

                case 3:
                    appointmentService.UpdateAppointment();
                    break;

                case 4:
                    appointmentService.DeleteAppointment();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("\nInvalid Choice!");
                    break;
            }

            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
    }
    private void RoomMenu()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("========== ROOM MANAGEMENT ==========");

        Console.WriteLine("1. Add Room");
        Console.WriteLine("2. View Rooms");
        Console.WriteLine("3. Update Room");
        Console.WriteLine("4. Delete Room");
        Console.WriteLine("0. Back");

        Console.Write("\nEnter Choice : ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                roomService.AddRoom();
                break;

            case 2:
                roomService.ViewRooms();
                break;

            case 3:
                roomService.UpdateRoom();
                break;

            case 4:
                roomService.DeleteRoom();
                break;

            case 0:
                return;

            default:
                Console.WriteLine("\nInvalid Choice!");
                break;
        }

        Console.WriteLine("\nPress Enter to Continue...");
        Console.ReadLine();
    }
}
}