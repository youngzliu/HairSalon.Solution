using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest
  {
    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist(){
      Stylist newStylist = new Stylist();
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }
  }
}
