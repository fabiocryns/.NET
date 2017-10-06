using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LinqModule;
using LinqModule.Model;
using LinqModule.Model.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqTests {
    [TestClass]
    public class QueryTests {
        [TestMethod]
        public void WhereQueryTest() {
            var q = new WhereQuery();
            string message;
            if (!ListContentsEquals(Solutions.WhereQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void SelectQueryTest() {
            var q = new SelectQuery();
            string message;
            if (!ListContentsEquals(Solutions.SelectQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void OrderByQueryTest() {
            var q = new OrderByQuery();
            string message;
            if (!ListEquals(Solutions.OrderByQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void GroupByQueryTest() {
            var q = new GroupByQuery();
            string message;
            if (!ListContentsEquals(Solutions.GroupByQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void CountQueryTest() {
            var q = new CountQuery();
            string message;
            if (!ObjectEquals(Solutions.CountQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void FilteredCountQueryTest() {
            var q = new FilteredCountQuery();
            string message;
            if (!ObjectEquals(Solutions.FilteredCountQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void CheapestProductQueryTest() {
            var q = new CheapestProductQuery();
            string message;
            if (!ObjectEquals(Solutions.CheapestProductQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void MostExpensiveProductQueryTest() {
            var q = new MostExpensiveProductQuery();
            string message;
            if (!ObjectEquals(Solutions.MostExpensiveProductQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void AverageProductPriceQueryTest() {
            var q = new AverageProductPriceQuery();
            string message;
            if (!ObjectEquals(Solutions.AverageProductPriceQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void InnerJoinQueryTest() {
            var q = new InnerJoinQuery();
            string message;
            if (!ListContentsEquals(Solutions.InnerJoinQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void LeftOuterJoinQueryTest() {
            var q = new LeftOuterJoinQuery();
            string message;
            if (!ListContentsEquals(Solutions.LeftOuterJoinQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void AnyQueryTest() {
            var q = new AnyQuery();
            string message;
            if (!ObjectEquals(Solutions.AnyQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void AllQueryTest() {
            var q = new AllQuery();
            string message;
            if (!ObjectEquals(Solutions.AllQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void ContainsQueryTest() {
            var q = new ContainsQuery();
            string message;
            if (!ObjectEquals(Solutions.ContainsQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void TakeQueryTest() {
            var q = new TakeQuery();
            string message;
            if (!ListContentsEquals(Solutions.TakeQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void SkipQueryTest() {
            var q = new SkipQuery();
            string message;
            if (!ListContentsEquals(Solutions.SkipQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void FirstQueryTest() {
            var q = new FirstQuery();
            string message;
            if (!ObjectEquals(Solutions.FirstQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void SingleQueryTest() {
            var q = new SingleQuery();
            string message;
            if (!ObjectEquals(Solutions.SingleQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void SingleOrDefaultQueryTest() {
            var q = new SingleOrDefaultQuery();
            string message;
            if (!ObjectEquals(Solutions.SingleOrDefaultQuery, q.Execute(), out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void DistinctQueryTest() {
            var q = new DistinctQuery();
            string message;
            if (!ListContentsEquals(Solutions.DistinctQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void UnionQueryTest() {
            var q = new UnionQuery();
            string message;
            if (!ListContentsEquals(Solutions.UnionQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void UnpopularProductsQueryTest() {
            var q = new UnpopularProductsQuery();
            string message;
            if (!ListContentsEquals(Solutions.UnpopularProductsQuery.Cast<object>(), q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        [TestMethod]
        public void BestSalesmenQueryTest() {
            var q = new BestSalesmenQuery();
            string message;
            if (!ListContentsEquals(Solutions.BestSalesmenQuery, q.Execute() as IEnumerable, out message))
                Assert.Fail(message);
        }

        private bool ListContentsEquals(IEnumerable<object> solutionEnum, IEnumerable enumB, out string message) {
            if (enumB == null) {
                message = string.Format("The returned object was a null reference.");
                return false;
            }
            var listA = solutionEnum.ToList();
            int count = 0;
            foreach (object b in enumB) {
                if (listA.Count == 0) {
                    message = string.Format("The returned list contains more items than expected.");
                    return false;
                }
                string res;
                var a = listA.Where(c => ObjectEquals(c, b, out res)).FirstOrDefault();
                if (a == null) {
                    message = string.Format("Lists do not contain the same objects.");
                    return false;
                }
                listA.Remove(a);
                count++;
            }
            if (listA.Count > 0) {
                message = string.Format("The returned list contains less items than expected.");
                return false;
            }

            message = null;
            return true;
        }
        private bool ListEquals(IEnumerable<object> solutionEnum, IEnumerable enumB, out string message) {
            if (enumB == null) {
                message = string.Format("The returned object was a null reference.");
                return false;
            }
            var listA = solutionEnum.ToList();
            int count = 0;
            foreach (object b in enumB) {
                if (listA.Count == 0) {
                    message = string.Format("The returned list contains more items than expected.");
                    return false;
                }
                string res;
                if (!ObjectEquals(listA[0], b, out res)) {
                    message = string.Format("Lists do not contain the same object at index {0}. {1}", count, res);
                    return false;
                }
                listA.RemoveAt(0);
                count++;
            }
            if (listA.Count > 0) {
                message = string.Format("The returned list contains less items than expected.");
                return false;
            }

            message = null;
            return true;
        }
        private bool ObjectEquals(object solution, object b, out string message) {
            if (b == null) {
                if (solution == null) {
                    message = null;
                    return true;
                } else {
                    message = string.Format("The returned object was a null reference.");
                    return false;
                }
            }

            if (solution is string || solution is ValueType) {
                if (Object.Equals(solution, b)) {
                    message = null;
                    return true;
                } else {
                    message = string.Format("The returned object had value '{0}' (expected value: '{1}').", b, solution);
                    return false;
                }
            }

            var bprops = b.GetType().GetProperties().ToList();
            foreach (var propA in solution.GetType().GetProperties()) {
                var propB = bprops.Where(p => p.Name == propA.Name).SingleOrDefault();
                if (propB == null) {
                    message = string.Format("The returned object did not contain the expected property {1}.", b.GetType().Name, propA.Name);
                    return false;
                }
                object valA = propA.GetValue(solution), valB = propB.GetValue(b);
                if (!Object.Equals(valA, valB)) {
                    message = string.Format("Property {0} has the value '{1}' (expected value: '{2}').", propA.Name, valB, valA);
                    return false;
                }
                bprops.Remove(propB);
            }
            if (bprops.Count > 0) {
                message = string.Format("The returned object contained more properties than expected ({0}).", string.Join(", ", bprops.Select(c => c.Name)));
                return false;
            }

            message = null;
            return true;
        }
    }
}