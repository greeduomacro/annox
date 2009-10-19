using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Accounting;

namespace Server.Engines.VeteranRewards
{
    public class SkillsCapOnlyRewardSystem
    {
        public static bool enable_SkillsCapRewards = true; // enable Skill Cap Reward
        public static int set_SkillsCapIncrease = 10; //increase by percent (aka 10% of current cap)
        public static TimeSpan RewardInterval = TimeSpan.FromDays(30.0);


        public static int GetRewardLevel(Mobile mob)
        {
            Account acct = mob.Account as Account;

            if (acct == null)
                return 0;

            return GetRewardLevel(acct);
        }

        public static int GetRewardLevel(Account acct)
        {
            TimeSpan totalTime = (DateTime.Now - acct.Created);

            int level = (int)(totalTime.TotalDays / RewardInterval.TotalDays);

            if (level < 0)
                level = 0;

            return level;
        }

        public static bool ConsumeRewardPoint(Mobile mob)
        {
            int cur, max;

            ComputeRewardInfo(mob, out cur, out max);

            if (cur >= max)
                return false;

            Account acct = mob.Account as Account;

            if (acct == null)
                return false;

            //if ( mob.AccessLevel < AccessLevel.GameMaster )
            acct.SetTag("numRewardsChosen", (cur + 1).ToString());

            return true;
        }

        public static void ComputeRewardInfo(Mobile mob, out int cur, out int max)
        {
            int level;

            ComputeRewardInfo(mob, out cur, out max, out level);
        }

        public static void ComputeRewardInfo(Mobile mob, out int cur, out int max, out int level)
        {
            Account acct = mob.Account as Account;

            if (acct == null)
            {
                cur = max = level = 0;
                return;
            }

            level = GetRewardLevel(acct);

            if (level == 0)
            {
                cur = max = 0;
                return;
            }

            string tag = acct.GetTag("numRewardsChosen");

            if (String.IsNullOrEmpty(tag))
                cur = 0;
            else
                cur = Utility.ToInt32(tag);

            if (level >= 6)
                max = 9 + ((level - 6) * 2);
            else
                max = 2 + level;
        }

        public static void Initialize()
        {
            if (enable_SkillsCapRewards)
                EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            Mobile from = args.Mobile;

            if (!from.Alive)
                return;

            int cur, max, level;

            ComputeRewardInfo(from, out cur, out max, out level);

            if (@level < 0 || @level > 12)
            {
                //    if (enable_SkillsCapRewards)
                //    {
                //        from.SendMessage("Current Skills Cap is:" + from.SkillsCap);
                //        from.SkillsCap = from.SkillsCap + (level * set_SkillsCapIncrease);
                //        from.SendMessage("New Skills Cap is:" + from.SkillsCap);
                //    }
                //}
                from.SendMessage("Current Skills Cap is:" + from.SkillsCap);
                switch (@level)  //picks one of the following
                {
                    case 0: break;
                    case 1: from.SkillsCap = from.SkillsCap + (level * set_SkillsCapIncrease); break;
                    case 2: from.SkillsCap = from.SkillsCap + (level * set_SkillsCapIncrease); break;
                    case 3: from.SkillsCap = from.SkillsCap + (level * set_SkillsCapIncrease); break;
                    case 4: from.SkillsCap = from.SkillsCap + (level * set_SkillsCapIncrease); break;
                    case 5: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 2); break;
                    case 6: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 2); break;
                    case 7: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 2); break;
                    case 8: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 2); break;
                    case 9: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 4); break;
                    case 10: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 4); break;
                    case 11: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 4); break;
                    case 12: from.SkillsCap = from.SkillsCap + ((level * set_SkillsCapIncrease) / 4); break;
                }
                from.SendMessage("New Skills Cap is:" + from.SkillsCap);
            }
        }
    }
}
