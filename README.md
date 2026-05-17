## Tsinswreng.Avln.Grid

Tsinswreng.Avln.Grid 提供一個圍繞 Avalonia `Grid` 的輕量疊加工具 `GridStack`。

它適合這種場景：

- 你想按行或按列依次往 `Grid` 裏塞控件
- 不想每次手動 `Grid.SetRow(...)` / `Grid.SetColumn(...)`
- 想用類似集合的方式逐個添加控件

### 安裝

```bash
dotnet add package Tsinswreng.Avln.Grid --version 0.0.1-alpha
```

### 示例

```csharp
var stack = new GridStack(isRow: true);
stack.RowDefs = new RowDefinitions("Auto,Auto,*");
stack.Add(new TextBlock{ Text = "A" });
stack.Add(new TextBlock{ Text = "B" });
```
