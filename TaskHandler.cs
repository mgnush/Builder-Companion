﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.IO;
using System.Diagnostics;

namespace Builder_Companion
{
    public static class TaskHandler
    {
        public async static Task<bool> RunPrimeFurmark(int durationMin)
        {            
            FurmarkHandler.InitFurmark(durationMin);
            TempHandler.InitTemp();

            await Task.Delay(2000);
            TempHandler.ReadTemp();
            await Task.Delay(2000);

            Task<bool> primeTask = PrimeHandler.RunPrime(durationMin);

            await Task.WhenAll(primeTask);

            return primeTask.Result;
        }

        public async static Task<bool> RunHeaven()
        {
            HeavenHandler.InitHeaven();
            await Task.Delay(14000 * 2 + 300000 + (1000 * 3));   // This delay matches the heaven run-time script
            
            return true;            
        }
    }
}
