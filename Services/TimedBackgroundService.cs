using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using AFKHastanesi.Models;

namespace HastaneRandevuSistemi.Services
{
    public class TimedBackgroundService : BackgroundService
    {
        private readonly ILogger<TimedBackgroundService> _logger;

        AppDbContext timerDbContext = new AppDbContext();

        public TimedBackgroundService(ILogger<TimedBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Timed Background Service is working at: {time}", DateTimeOffset.Now);

                // Buraya düzenli aralıklarla çalışmasını istediğiniz kodu ekleyebilirsiniz.

                bool checkDoktor = timerDbContext.Doktorlar.Any();

                if (checkDoktor)
                {
                    List<Doktor> doktors = timerDbContext.Doktorlar.ToList();
                    foreach (var doktor in doktors)
                    {
                        for (int g = 0; g < 30; g++)
                        {
                            for (int i = 9; i < 16; i++)
                            {
                                if (i == 13)
                                {
                                    continue;
                                }
                                else
                                {
                                    DateTime suankiTarihVeSaat = DateTime.Now.AddDays(g);
                                    DateTime randevuTime1 = new DateTime(suankiTarihVeSaat.Year, suankiTarihVeSaat.Month, suankiTarihVeSaat.Day, i, 0, 0).ToUniversalTime();
                                    DateTime randevuTime2 = new DateTime(suankiTarihVeSaat.Year, suankiTarihVeSaat.Month, suankiTarihVeSaat.Day, i, 30, 0).ToUniversalTime();
                                    int poliklinikId = timerDbContext.Poliklinikler.SingleOrDefault(p => p.DoktorID == doktor.DoktorID).PoliklinikID;

                                    Randevu randevu = new Randevu() { 
                                        DoktorID = doktor.DoktorID,
                                        BilimDaliID= timerDbContext.Doktorlar.SingleOrDefault(d=>d.DoktorID==doktor.DoktorID).BilimDaliID,
                                        PoliklinikID= poliklinikId,
                                        RandevuDurumID = 4,
                                        RandevuTarihi= randevuTime1
                                    };

                                    Randevu randevu2 = new Randevu()
                                    {
                                        DoktorID = doktor.DoktorID,
                                        BilimDaliID = timerDbContext.Doktorlar.SingleOrDefault(d => d.DoktorID == doktor.DoktorID).BilimDaliID,
                                        PoliklinikID = poliklinikId,
                                        RandevuDurumID = 4,
                                        RandevuTarihi = randevuTime2
                                    };

                                    timerDbContext.Randevular.Add(randevu);
                                    timerDbContext.Randevular.Add(randevu2);
                                }
                            }
                        }
                        timerDbContext.SaveChanges();
                    }
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); 
            }
        }
    }
}

