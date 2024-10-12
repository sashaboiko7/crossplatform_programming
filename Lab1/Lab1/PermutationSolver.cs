using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class PermutationSolver
    {
        public static IEnumerable<string> GetPermutations(string str)
        {
            if (str.Length == 1)
                yield return str;
            else
            {
                foreach (var c in str)
                {
                    var remaining = new string(str.Where(x => x != c || str.Count(ch => ch == c) > 1).ToArray());
                    foreach (var permutation in GetPermutations(remaining))
                    {
                        yield return c + permutation;
                    }
                }
            }
        }

        public static string Solve(int a, int b, int c)
        {
            if (a == 0 && b == c) return $"YES\n0 {b}";
            if (b == 0 && a == c) return $"YES\n{a} 0";

            var aPerms = GetPermutations(a.ToString())
                .Select(x => int.Parse(x))
                .Distinct()
                .Where(x => x.ToString() == x.ToString().TrimStart('0'))
                .OrderBy(x => x);

            var bPerms = GetPermutations(b.ToString())
                .Select(x => int.Parse(x))
                .Distinct()
                .Where(x => x.ToString() == x.ToString().TrimStart('0'))
                .OrderBy(x => x);

            foreach (var x in aPerms)
            {
                foreach (var y in bPerms)
                {
                    if (x + y == c)
                    {
                        return $"YES\n{x} {y}";
                    }
                }
            }

            return "NO";
        }
    }
}
