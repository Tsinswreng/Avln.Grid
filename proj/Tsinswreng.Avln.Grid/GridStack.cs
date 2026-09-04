namespace Tsinswreng.Avln.Grid;

using Avalonia.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using Tsinswreng.CsCore;


public partial class GridStack
	:ICollection<Control>
{

	public Grid Grid{get;set;} = new Grid();
	public i32 Index{get;set;} = 0;
	public bool IsRow{get;set;} = true;

	public GridStack(bool IsRow = true){
		this.IsRow = IsRow;
	}

	public int Count => Grid.Children.Count;

	public bool IsReadOnly => false;

	protected ICollection<Control> Inner{get{
		return Grid.Children;
	}}

	[Impl]
	public void Add(Control Control= default!){
		if(Control == null){
			Index++;
			//return NIL;
			return;
		}
		Grid.Children.Add(Control);
		if(IsRow){
			Grid.SetRow(Control, Index++);
		}else{
			Grid.SetColumn(Control, Index++);
		}
		//return NIL;
		return;
	}

	[Impl]
	public void Clear() {
		Inner.Clear();
	}

	[Impl]
	public bool Contains(Control item) {
		return Inner.Contains(item);
	}

	[Impl]
	public void CopyTo(Control[] array, int arrayIndex) {
		Inner.CopyTo(array, arrayIndex);
	}

	[Impl]
	public IEnumerator<Control> GetEnumerator() {
		return Inner.GetEnumerator();
	}

	[Impl]
	public bool Remove(Control item) {
		return Inner.Remove(item);
	}

	[Impl]
	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}

public static class ExtnGridStack {
	extension(GridStack z){
		public ColumnDefinitions ColDefs{
			get{
				return z.Grid.ColumnDefinitions;
			}
			set{
				z.Grid.ColumnDefinitions = value;
			}
		}
		public RowDefinitions RowDefs{
			get{
				return z.Grid.RowDefinitions;
			}set{
				z.Grid.RowDefinitions = value;
			}
		}
	}
	
	extension<TSelf>(TSelf z)
		where TSelf : GridStack
	{
		public TSelf SetRowDefs(
			params IEnumerable<RowDefinition> RowDefs
		){
			z.Grid.RowDefinitions = [..RowDefs];
			return z;
		}

		public TSelf SetColDefs(
			params IEnumerable<ColumnDefinition> ColDefs
		){
			z.Grid.ColumnDefinitions= [..ColDefs];
			return z;
		}
	}
}
