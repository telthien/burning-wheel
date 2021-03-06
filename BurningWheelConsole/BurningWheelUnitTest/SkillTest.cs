﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;
using System.Collections.Generic;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class SkillTest
    {
        [TestMethod]
        public void SkillIsNotReference()
        {
            Skill p = SkillIndex.getSkillByName("Ship-wise");
            Skill q = SkillIndex.getSkillByName("Ship-wise");
            Assert.IsNotNull(p); Assert.IsNotNull(q);
            Assert.AreNotSame(p, q);
        }

        [TestMethod]
        public void SkillFetchByName()
        {
            Skill p = SkillIndex.getSkillByName("Ship-wise");
            Assert.IsNotNull(p);
            Skill q = SkillIndex.getSkillByName("Schtroumpfed-wise");
            Assert.IsNull(q);
        }

        [TestMethod]
        public void NoTwoSkillsWithSameName()
        {
            List<Skill> SkillList = JsonConvert.DeserializeObject<List<Skill>>(Resources.SkillsJSON);
            for (int i = 0; i < SkillList.Count; i++)
            {
                for (int j = 0; j < SkillList.Count; j++)
                {
                    if (i == j) continue;
                    if (!SkillList[i].Name.Equals(SkillList[j].Name)) continue;
                    Assert.Fail("Duplicate skill: " + SkillList[i].Name);
                }
            }
        }
    }
}
