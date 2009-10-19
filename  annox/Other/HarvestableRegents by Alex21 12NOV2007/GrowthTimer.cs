using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;

namespace Server.Items
{
    public class GrowthTimer : Timer
    {

        public static void Initialize()
        {
            new GrowthTimer();
        }

        private static ArrayList plants;

        public GrowthTimer()
            : base(TimeSpan.FromMinutes(45))
        {
            plants = new ArrayList();
            Priority = TimerPriority.OneSecond;
            this.Start();
        }

        protected override void OnTick()
        {
            foreach (Item item in World.Items.Values)
            {
                if (item is BaseRegentPlant)
                {
                    BaseRegentPlant plant = (BaseRegentPlant)item;

                    if (plant.Held < 12)
                    {
                        plants.Add(plant);
                    }
                    else if (plant.Held >= 12 && plants.Contains(plant))
                    {
                        plants.Remove(plant);
                    }
                }
            }

            for (int i = 0; i < plants.Count; ++i)
            {
                BaseRegentPlant plant = (BaseRegentPlant)plants[i];

                if (plant.Held < 12)
                    plant.Held += 1;
            }
            Console.WriteLine("Regent Plant Growth Check.");
            GrowthTimer tmr = new GrowthTimer();
            tmr.Start();
            this.Stop();
        }
    }
}