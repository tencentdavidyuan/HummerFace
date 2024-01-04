# <font color = red> Quick start </font>

## <font color = blue> Example Scenes </font>

    查看示例场景。 有不少位于 UMA\Examples 中。 首先要检查的是 “UMA DCS Demo - Simple Setup”。

## <font color = blue> New Scene </font>

    1）打开 UMA/Getting Started 文件夹——该文件夹包含各种预制件，可用于快速入门。
    2) 找到预制件 “UMA_GLIB” 并将其拖到场景中。 这是包含 UMA 上下文、生成器和 mesh combiner 的对象。 该预制件中的上下文直接进入 UMA Asset Index 来访问项目。
    3) 接下来，找到预制件 “UMADynamicCharacterAvatar” 并将其拖到场景中。 这将是一个 UMA avatar。 它包含脚本 “DynamicCharacterAvatar”。
    4) 将其位置设置到您想要的任何位置，并确保头像对象下方有一个对象或地形。 另外，请确保它位于游戏摄像机的视野范围内。 它应该生成并显示角色，并允许您在检查器的自定义部分中对其进行更改：

    5) 从这里你可以更改为其他种族或添加新的衣柜物品、更新颜色、添加 DNA 并更改它等。请注意，只有与当前角色种族匹配的衣柜物品才会加载，但你仍然可以添加其他物品 其他种族。

# Basic Concepts

## UMAGlobalContext and UMAContext

UMAGlobalContext 包含访问生成 UMA 字符所需资产的方法。它可以直接从全局库中访问这些项目。UMA/Getting Started 文件夹（UMA_GLIB）中提供了一个为大多数使用情况设置的预制板。

还有另一个上下文（UMAContext）可以访问一组库中的资源。 它从存储场景中项目引用的各种库中加载项目。 保留此上下文是为了与旧代码兼容。 建议在使用 UMA 2.10 时使用全局上下文。

场景中需要某种类型的上下文，UMA 系统才能正常工作。 您可以创建一次，并设置标志“不要在加载时销毁”以使其常驻 - 这样做需要您以特定的方式构建游戏，这超出了本文档的范围。 请参阅 https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html 了解更多信息。


## <font color = blue> UMAGenerator </font>

UMAGenerator 组件包含在预制件的 UMAContext 中。 该组件用于调整 UMA Avatars 的生成。

FitAtlas : 除非您提供了自己的纹理合并预制板，否则应将此值设置为 true。设置此值后，纹理将根据需要进行缩减，以使所有纹理都能放入图集中。

Convert Render Textures : 选中此项会将生成的纹理从 RenderTextures 转换为 Standard Texture2D。 这将大大减慢生成过程，但也允许您以编程方式更改纹理位。 除非您特别需要此功能，否则不建议设置此功能。

Convert Mip Maps : 检查此项将生成 mipmap。 这是推荐的。

Atlas Resolution : 这将设置生成的纹理图集的最大尺寸。

Default Overlay Asset : 如果在生成过程中没有找到覆盖层，则用此覆盖层代替。

Initial Scale Factor : 这是覆盖层添加到地图集时应用的比例因子。将缩放因子设置为 2 会使所有覆盖层的大小除以 2。通常情况下，该系数应设置为 1，并通过增加该系数来提高内存使用率。

Fast Generation : 如果选中此选项，UMA 将为一帧中排队的 UMA 生成骨架和网格。 如果未选中此项，它们将在单独的帧中生成。

Iteration Count : 迭代次数

Garbage Collection Rate : 在收集垃圾和释放内存之前需要进行多少次迭代。

Process All Pending : 如果选中此项，所有 UMA 将在下一帧生成。

Texture Merge prefab : 如果您提供自己的纹理合并模块，则应将其包含在此预制件中。 这是一个高级选项。

Mesh Combiner : 如果您提供自己的网格组合器，它应该包含在此预制件中。 这是一个高级选项。

Editor Time Atlas Resolution : 这是编辑期间使用的图集大小。 您可以将其降低，以便在编辑过程中生成速度更快。

Edit Time Scale Factor : 与其他编辑时间选项一样，它用于调整编辑时间生成，并在编辑时间期间代替初始比例因子

Sharper Fit Textures : 当纹理不适合图集时，它们将被调整大小以适应。 选中此框将告诉生成器使用更高的 mip 贴图来缩小尺寸。 如果未选中此选项，则默认情况下是让驱动程序决定使用哪个 mipmap，通常会导致贴合纹理稍微模糊。

Atlas Overflow Fit Method : Best Fit Square - 使用此方法，当图集超额预订时，生成器将创建尽可能大的正方形来包含图集纹理，然后减少纹理以完全适合图集。 这样可以最大限度地减少浪费的空间并提高分辨率。 这是 UMA 2.11 的默认设置。Decrease Resolution - 使用此方法，系统将尝试按百分比减小纹理大小以适合图集。 可以指定每次拟合过程减少的百分比大小（UMA 的早期版本使用此方法，硬编码值为 0.5）。


## <font color = blue> Dynamic Character Avatar </font>

DynamicCharacterAvatar 是利用 UMA 和衣柜系统的最高级别组件。 它允许您轻松选择种族、设置事件、角色颜色和默认衣柜配方。 名为 UMADynamicCharacterAvatar 的默认预制件位于 UMA/Getting Started 文件夹中。

Wardrobe System

The Wardrobe system 引入了 "Wardrobe Recipes（衣橱配方）" 的概念。通过这些容器，您可以选择要使用的兼容种族、衣柜插槽（不要与普通插槽混淆）以及其他配置选项。最后，您还可以添加代表该衣柜配方的各种 slots and overlays 层。从本质上讲，这包含了 "物品 "或 "衣物 "的概念，可以作为一个对象使用。每个衣柜物品都将包含一个或多个插槽，以及每个插槽的一个或多个覆盖层。它们甚至可以包含已在基础种族配方或其他衣橱插槽中使用过的插槽。在这种情况下，多余的插槽会被合并掉，而覆盖层会被添加到现有的插槽中。例如，如果您想在脸上纹一个纹身，您就需要添加一个脸部插槽和一个纹身叠加--尽管基础种族已经有一个脸部插槽（带有脸部叠加）。在创建角色时，额外的脸部插槽将被移除，纹身叠加将添加到脸部叠加之后。


