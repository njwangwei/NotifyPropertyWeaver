﻿using System.Linq;
using NUnit.Framework;

[TestFixture]
public class WithUnderScoreFields
{
    [Test]
    public void Run()
    {
        var typeDefinition = DefinitionFinder.FindType<Person>();
        var node = new TypeNode
        {
            TypeDefinition = typeDefinition,
            Mappings = MappingFinder.GetMappings(typeDefinition).ToList()
        };
        new IlGeneratedByDependencyReader(node).Process();

        Assert.AreEqual("FullName", node.PropertyDependencies[0].ShouldAlsoNotifyFor.Name);
        Assert.AreEqual("GivenNames", node.PropertyDependencies[0].WhenPropertyIsSet.Name);
        Assert.AreEqual("FullName", node.PropertyDependencies[1].ShouldAlsoNotifyFor.Name);
        Assert.AreEqual("FamilyName", node.PropertyDependencies[1].WhenPropertyIsSet.Name);
    }

    public class Person
    {
        // ReSharper disable InconsistentNaming
        string _givenNames;
        // ReSharper restore InconsistentNaming
        public string GivenNames
        {
            get { return _givenNames; }
            set { _givenNames = value; }
        }

        // ReSharper disable InconsistentNaming
        string _familyName;
        // ReSharper restore InconsistentNaming
        public string FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", _givenNames, _familyName);
            }
        }
    }
}