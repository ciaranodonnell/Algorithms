using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms
{
	class ContinuousMedians
	{


		public static void MyMain(string[] args)
		{
			
			int caseCount = int.Parse(Console.ReadLine());
			List<int> means = new List<int>();

			for (int x = 0; x < caseCount; x++)
			{
				ContinuousMedians m = new ContinuousMedians();
				int continousMedian = 0;
				var arrayLength = Console.ReadLine();
				foreach (var i in Console.ReadLine().Split(" ").Select(s => int.Parse(s)))
				{
					var median = m.Add(i);
					continousMedian += median;
				}
				means.Add(continousMedian);
			}

			means.ForEach(i => Console.WriteLine(i));
		}



		LinkedList<int> values = new LinkedList<int>();
		bool first = true;
		private LinkedListNode<int> medianNode;
		bool moveMedian = false;
		public int Add(int value)
		{
			int newMedian = 0;

			if (first)
			{
				first = false;
				this.medianNode = values.AddLast(value);
				return value;
			}

			var insertedBeforeMedian = InsertInPlace(value);
			if (insertedBeforeMedian && moveMedian == false) medianNode = medianNode.Previous;
			if (moveMedian)
			{
				if (!insertedBeforeMedian) medianNode = medianNode.Next;
				moveMedian = false;
				return medianNode.Value;
			}
			else
			{
				moveMedian = true;
				return ((medianNode.Value + medianNode.Next.Value) / 2);

			}


		}

		private bool InsertInPlace(int value)
		{
			if (value >= values.Last.Value)
			{
				values.AddLast(value);
				return false;
			}
			if (value <= values.First.Value)
			{
				values.AddFirst(value);
				return true;
			}

			if (value <= medianNode.Value)
			{
				var node = medianNode.Previous;
				while (value <= node.Value) node = node.Previous;
				values.AddAfter(node, value);
				return true;
			}
			else
			{
				var node = medianNode.Next;
				while (value >= node.Value) node = node.Next;
				values.AddBefore(node, value);
				return false;
			}


		}
	}
}
