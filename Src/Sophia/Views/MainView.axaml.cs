using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using SliccDB.Serialization;

namespace Sophia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        DatabaseConnection connection = new DatabaseConnection("database", true);
        var properties = new Dictionary<string, string>();
        var labels = new HashSet<string>();
        properties.Add("Name", "Alice");
        labels.Add("Person");

        var nodeOne = connection.CreateNode(properties, labels);
        properties.Clear();
        labels.Clear();
        properties.Add("Name", "Steve");
        labels.Add("Person");

        var nodeTwo = connection.CreateNode(properties, labels);

        var p = new Dictionary<string, string>();
        var l = new HashSet<string>();
        p.Add("How Much", "Very Much");
        l.Add("Label on a node!");
        connection.CreateRelation(
        "Likes", 
        sn => sn.First(x => x.Hash == nodeOne.Hash), tn => tn.First(a => a.Hash == nodeTwo.Hash), p, l);

    }
}