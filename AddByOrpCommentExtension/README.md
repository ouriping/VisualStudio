# Add By Orp Comment Extension

一个 Visual Studio 2022 扩展，提供实时日期/时间注释补全功能。

## 功能特性

- 🚀 **实时日期时间**：自动获取系统当前日期和时间
- ⚡ **快速触发**：输入 `addbyorp` 快捷键自动补全
- 📝 **标准格式**：生成格式 `// add by orp YYYY.MM.DD HH:mm:ss`
- 🎯 **智能补全**：与 VS2022 IntelliSense 完全集成

## 安装方法

### 方法 1：从源代码构建

1. 克隆仓库
```bash
git clone https://github.com/ouriping/VisualStudio.git
cd VisualStudio/AddByOrpCommentExtension
```

2. 用 Visual Studio 2022 打开 `AddByOrpCommentExtension.csproj`

3. 构建项目
```
Build > Build Solution
```

4. 运行扩展
```
F5 (Debug) 或 Ctrl+F5 (Release)
```

5. 构建 VSIX 包
```
Build > Build AddByOrpCommentExtension
```

在 `bin/Release` 文件夹中会生成 `.vsix` 文件。

### 方法 2：安装 VSIX 文件

1. 下载最新的 `.vsix` 文件
2. 双击打开或在 Visual Studio 中选择：
   ```
   Extensions > Manage Extensions
   ```
3. 搜索并安装该扩展
4. 重启 Visual Studio

## 使用方法

### 在 C# 代码中使用

1. 打开任何 `.cs` 文件
2. 输入 `addbyorp`
3. 按 `Tab` 或 `Enter` 自动补全
4. 得到：`// add by orp 2026.06.23 12:34:56`

### 示例

```csharp
public class Example
{
    public void Method()
    {
        addbyorp  // 输入此处
        // 按 Tab 键自动补全为
        // add by orp 2026.06.23 12:34:56
        var result = CalculateValue();
    }
}
```

## 系统要求

- ✅ Visual Studio 2022 版本 17.0 及以上 (包括 17.14)
- ✅ .NET Framework 4.7.2 或更高版本
- ✅ Windows 操作系统

## 技术栈

- **框架**：Visual Studio SDK (VSSDK) 17.0+
- **语言**：C# 9.0+
- **API**：AsyncCompletion, MEF (Managed Extensibility Framework)

## 配置选项

默认设置：
- 触发快捷键：`addbyorp`
- 日期格式：`YYYY.MM.DD HH:mm:ss`
- 作者标识：`orp`

## 故障排除

### 补全不工作

1. 检查扩展是否已安装：
   ```
   Extensions > Manage Extensions > 搜索 "Add By Orp"
   ```

2. 确保在 C# 文件中 (`.cs` 扩展名)

3. 检查 IntelliSense 是否启用：
   ```
   Tools > Options > Text Editor > C# > Advanced > IntelliSense
   ```

### 卸载扩展

```
Extensions > Manage Extensions > 搜索 "Add By Orp" > Uninstall
```

## 贡献

欢迎提交 Issue 和 Pull Request！

## 许可证

MIT License

## 作者

- 开发者：ouriping
- 项目：AddByOrpCommentExtension

---

**最后更新**：2026-06-23
