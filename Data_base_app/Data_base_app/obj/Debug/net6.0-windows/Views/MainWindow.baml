   M S B A M L   `   `   `  ????H  DData_base_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Data_base_appData_base_app  5   	   A%clr-namespace:Data_base_app.ViewModelData_base_app.ViewModel  5   	       Data_base_app.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Data_base_app     5   	   ;	viewmodel%clr-namespace:Data_base_app.ViewModel     5   	     ? Title$  
MainWindow??5	   	      WindowStyle#??[  6   $	??450??6B   $	??800??6O    ? DataContext 5      *  $Data_base_app.ViewModel.AppViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   o? -   5         o?Name$ mainMenu??5      $	??Top=?5      $??25??5      .@?5      m?  
 m_File#??[ 6   .@?5      m?   m_import#??[ 6   .@?5      m?   	m_XMLfile#??[ 6    m? CommandParameter$	 xml??5       m? Command 5      ?? *ImportCommandHandler+5      m? 5        
m_JSONfile#??[ 6   $
 json??5       5      ?? *ImportCommandHandler+5      5!      m? 5"        m_saveAs#??[ 6   .@?5#      m? #??[ 6   $	 xml??5%       5$      ?? *ExportCommandHandler+5%      m? 5&      #??[ 6   $
 json??5(       5'      ?? *ExportCommandHandler+5(      5)      ?? 5*      m? 5+       
 m_exit#??[ 6    5,      ?? *ExitCommandHandler+5-      m? 5.       
 m_Edit#??[ 6   .@?5/      m?   m_editEmployee#??[ 6    6D   ?? *OpenEditWindowCommandHandler+m? 50       	 m_newEmployee#??[	 6    6C   ?? *OpenAddWindowCommandHandler+m? 51       
 m_deleteEmployee#??[
 6    6F   ?? *DeleteCommandHandler+52      m? 53        
m_Settings#??[ 6   .@?54      m? -   5         m?Name$ themeCheckBox??54        m_darkTheme#??[ 55       m? IsCheckable$
 True??56       m? 	IsChecked$
 True??57       58      ?? *ChangeThemeCommandHandler+ 59      ?? 	 ?? ElementName$	 themeCheckBox??
 ?? Path$
 	IsChecked?5:      5;      ?? 5=   
   $??1??6     	AddButton#??[ 6   ??6B   ?? *OpenAddWindowCommandHandler+.??5>      ??   button_addEmployee#??[ 6   5?      ?? 5A   
   $??2??6    ?? Orientation$ 
Horizontal=?6"   $??Center=?5B      .+?5C      ??   
EditButton#??[ 6     button_edit#??[ 5D   )   ??5E   )   ?? *OpenEditWindowCommandHandler+?? 5F        DeleteButton#??[ 6     button_delete#??[ 5G   )   ??5H   )   ?? *DeleteCommandHandler+5I      &   System.Windows.Controls.DataGrid  5K   
   -   5          Name$ Table??5K      $??3??5L        DataGridStyle#??[ 5M        DataGridRowStyle   RowStyle# [ 5N        DataGridCellStyle   	CellStyle# [ 5O        DataGridColumnHeaderStyle   ColumnHeaderStyle# [ 5P       ?? SelectedItem 5Q      ?? *SelectedEmployee+??5R      ?? *
Database+   Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T        employee_name,  &System.Windows.Controls.DataGridColumn   Header# [ 6%      
IsReadOnly$
 True??6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6_   ?? *Name+  5U        employee_position# [ 6%   $
 True??6Q    6c   ?? *
Position+  5V        employee_age# [ 6%   $
 True??6L      MinWidth$ 50Q?6v    6^   ?? *Age+6v   4  .System.Windows.Controls.DataGridCheckBoxColumn  5W        employee_married# [ 6)   $
 True??6T   $ 40Q?6?    6f   ?? *	Married+ ?? UpdateSourceTrigger$ PropertyChanged=?6?     5X        employee_phone# [ 6%   $
 True??6N    6`   ?? *Phone+ ?? ValidatesOnExceptions$
 True?? ?? StringFormat$ {0:+### (##) ###-##-##}??  5Y        employee_emplDate# [ 6%   $
 True??6Q    6c   ?? *EmploymentDate+$ {0:dd.MM.yyyy}?? ? ContextMenu 5[      ?? 5\      .@?5]      m? #??[	 6    5^      ?? *OpenAddWindowCommandHandler+m? 5_      #??[ 6    5`      ?? *OpenEditWindowCommandHandler+m? 5a      #??[
 6    5b      ?? *DeleteCommandHandler+5c      5e      5f      5g      