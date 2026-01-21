using System;
using System.Collections.Generic;

// Represents a single insurance policy
class InsurancePolicy
{
    public int Number { get; }
    public string Coverage { get; }
    public DateTime Expiry { get; }

    public InsurancePolicy(int number, string coverage, DateTime expiry)
    {
        Number = number;
        Coverage = coverage;
        Expiry = expiry;
    }

    // Policy number uniquely identifies a policy
    public override bool Equals(object obj)
    {
        if (obj is InsurancePolicy other)
            return this.Number == other.Number;

        return false;
    }

    public override int GetHashCode()
    {
        return Number;
    }

    public override string ToString()
    {
        return $"{Number} | {Coverage} | Expiry: {Expiry:dd-MM-yyyy}";
    }
}

class Program
{
    static void Main()
    {
        // Stores unique policies (fast lookup)
        HashSet<InsurancePolicy> policySet = new HashSet<InsurancePolicy>();

        // Preserves insertion order (LinkedHashSet behavior)
        List<InsurancePolicy> orderedPolicies = new List<InsurancePolicy>();

        // Keeps policies sorted by expiry date
        SortedSet<InsurancePolicy> expirySortedPolicies =
            new SortedSet<InsurancePolicy>(Comparer<InsurancePolicy>.Create(
                (x, y) =>
                {
                    int result = x.Expiry.CompareTo(y.Expiry);

                    // If expiry dates match, compare policy numbers
                    return result == 0 ? x.Number.CompareTo(y.Number) : result;
                }
            ));

        // Add policies
        InsertPolicy(new InsurancePolicy(101, "Health", DateTime.Now.AddDays(10)));
        InsertPolicy(new InsurancePolicy(102, "Car", DateTime.Now.AddDays(40)));
        InsertPolicy(new InsurancePolicy(103, "Health", DateTime.Now.AddDays(20)));
        InsertPolicy(new InsurancePolicy(101, "Life", DateTime.Now.AddDays(5))); // duplicate

        // ---------- DISPLAY DATA ----------

        Console.WriteLine("\nAll Unique Policies:");
        foreach (var policy in orderedPolicies)
            Console.WriteLine(policy);

        Console.WriteLine("\nPolicies Expiring Within 30 Days:");
        DateTime threshold = DateTime.Now.AddDays(30);
        foreach (var policy in expirySortedPolicies)
        {
            if (policy.Expiry <= threshold)
                Console.WriteLine(policy);
        }

        Console.WriteLine("\nPolicies with Health Coverage:");
        foreach (var policy in policySet)
        {
            if (policy.Coverage.Equals("Health", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(policy);
        }

        Console.WriteLine("\nPolicies Sorted By Expiry Date:");
        foreach (var policy in expirySortedPolicies)
            Console.WriteLine(policy);

        // ---------- LOCAL FUNCTION ----------
        void InsertPolicy(InsurancePolicy policy)
        {
            // HashSet ensures uniqueness
            if (!policySet.Add(policy))
            {
                Console.WriteLine($"Duplicate policy ignored: {policy.Number}");
                return;
            }

            orderedPolicies.Add(policy);
            expirySortedPolicies.Add(policy);
        }
    }
}
