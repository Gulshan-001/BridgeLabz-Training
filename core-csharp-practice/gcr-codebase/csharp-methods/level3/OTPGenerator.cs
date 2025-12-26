using System;

    class OTPGenerator
    {
        // a. Generate 6-digit OTP
        public static int GenerateOTP()
        {
            Random rand = new Random();
            return rand.Next(100000, 1000000);
        }        
        // c. Check if all OTPs are unique
        public static bool AreOTPsUnique(int[] otps)
        {
            for (int i = 0; i < otps.Length; i++)
            {
                for (int j = i + 1; j < otps.Length; j++)
                {
                    if (otps[i] == otps[j])
                        return false;
                }
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] otpArray = new int[10];

            for (int i = 0; i < otpArray.Length; i++)
            {
                otpArray[i] = OTPGenerator.GenerateOTP();
            }

            Console.WriteLine("Generated OTPs:");
            for (int i = 0; i < otpArray.Length; i++)
            {
                Console.WriteLine(otpArray[i]);
            }

            bool isUnique = OTPGenerator.AreOTPsUnique(otpArray);
            Console.WriteLine("All OTPs are unique? " + (isUnique ? "Yes" : "No"));
        }
    }