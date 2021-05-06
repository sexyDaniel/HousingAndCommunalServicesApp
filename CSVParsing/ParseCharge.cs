using GKU_App.CSVParsing.Interfaces;
using GKU_App.DataBaseContext;
using GKU_App.Logger;
using GKU_App.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.CSVParsing
{
    public class ParseCharge : IParseCharge
    {
        private AppDbContext dbContext;

        public ParseCharge(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void ParsingCharge(string pathCsvFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathCsvFile))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        var values = line.Split(";");

                        Charge charge = new Charge();
                        charge.ServiceId = Convert.ToInt32(values[0]);
                        charge.PropertyId = Convert.ToInt32(values[1]);
                        charge.ChargeDate = Convert.ToDateTime(values[2]);
                        charge.Volume = Convert.ToDouble(values[3]);

                        if (!dbContext.Charges.Any(c => c.ServiceId == charge.ServiceId &&
                        c.PropertyId == charge.PropertyId && c.ChargeDate == charge.ChargeDate &&
                        c.Volume == charge.Volume))
                        {
                            dbContext.Charges.Add(charge);
                            dbContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.ErrorUnique("Error reading CSV file.", e);
            }
        }
    }
}
