﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;
using System.Collections.Generic;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class TraitTest
    {
        [TestMethod]
        public void TraitIsNotReference()
        {
            Trait p = TraitIndex.getTraitByName("Veneer of Obedience");
            Trait q = TraitIndex.getTraitByName("Veneer of Obedience");
            Assert.IsNotNull(p); Assert.IsNotNull(q);
            Assert.AreNotSame(p, q);
        }

        [TestMethod]
        public void TraitFetchByName()
        {
            Trait p = TraitIndex.getTraitByName("Veneer of Obedience");
            Assert.IsNotNull(p);
            Trait q = TraitIndex.getTraitByName("SuperHappyFunTrait");
            Assert.IsNull(q);
        }

        [TestMethod]
        public void NoTwoTraitsWithSameName()
        {
            List<Trait> TraitList = JsonConvert.DeserializeObject<List<Trait>>(Resources.TraitsJSON);
            for (int i = 0; i < TraitList.Count; i++)
            {
                for (int j = 0; j < TraitList.Count; j++)
                {
                    if (i == j) continue;
                    if (!TraitList[i].Name.Equals(TraitList[j].Name)) continue;
                    Assert.Fail("Duplicate trait: " + TraitList[i].Name);
                }
            }
        }
    }
}
