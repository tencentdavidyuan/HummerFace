# 什么是 UMA Dynamic Character System（动态角色系统）？

## Overview

### <font color=blue> What is the UMA Dynamic Character System?  </font>


动态角色系统（DCS）是 UMA 内置的一个系统，可将您的 UMA 变成一个拥有种族和服装的角色。动态角色系统的核心是动态角色头像（DCA）。每个 DCA 都会管理自己的颜色、衣橱物品（不仅包括服装，还包括头发、肤色等），并确保结果一致--例如，添加一个蓬巴杜发型将替换角色现有的任何头发，并确保其颜色一致。


### <font color=blue> Let’s get started!  </font>

首先，创建一个新场景。在 UMA/Getting Started（UMA/入门）文件夹中有两个 prefabs。将 UMA_GLIB prefab 放到场景中，这样系统就设置好了。此时不需要做任何更改。在场景中创建一个 3D 立方体，并将其缩放至 10,1,10，然后将 UMADynamicCharacterAvatar（动态角色头像）预制板拖入场景，放在其顶部。如果新的预制件未被选中，请在场景层次结构中选中它并按 "f "键对焦。它应该会显示 "人类男性 "种族的 UMA 角色。确保场景摄像机对准角色，然后按播放键。你的第一个角色应该站在立方体上，看起来有点可疑。

### <font color=blue> DCA 角色可即时重新组合 </font>

也许您不希望它是一个 "男性人类"（这是默认设置）。让我们将其更改为 "女性人类"--在场景层次结构中选择 UMADynamicCharacterAvatar，然后查看检查器。活动种族应该显示为 "人类男性"。将其更改为 "人类女性"。角色应该会在场景视图中发生变化。

再按一次播放停止。确保活动种族设置为 "男性人类"，然后继续。

### <font color=blue> 让我们给它穿上一些衣服和功能。</font>

在项目视图中，键入 t:UMAWardrobeRecipe 将视图过滤为 wardrobe recipes。在 DynamicCharacterAvatar 组件上，打开 "Customization" 下拉菜单，然后打开 "Default Wardrobe Recipes" 折叠。将 "MaleHair1 "和 "MaleRobe "拖放到拖动区域。由于这些配方适用于人类男性种族，因此它们将被装备上。(注："The Default Wardrobe" 用于在启动时自动添加到角色的物品。这不是角色的衣橱，只是可以添加到衣橱的物品列表。当您在插槽中添加不同物品时，角色衣橱会自动取消插槽中物品的装备）。

wardrobe n.衣柜，衣橱；（某人的）全部服装；（剧院、电视台等的）服装部，戏装管理部

假设您希望他晒黑一点 - 打开 DCA 组件上的 “Character Colors” 折叠页，然后找到“皮肤”颜色。 单击基色，然后选择漂亮的棕褐色。 嗯——看起来有点平淡，所以让我们添加一点光泽。 单击金属光泽颜色，并将 Alpha 设置为大约 50。尝试使用这些颜色，直到找到您喜欢的颜色。

下一步是打开 UMA DCS 演示 – 简单设置场景。

该场景展示了如何通过编程更改服装、颜色和 DNA。这是一个完整的角色设计器，代码都在 SampleCode 对象上的 SampleCode 类中。

按下 "播放"，然后点击 "随机化 "几次。头像会自动重建。

更改衣橱"、"更改颜色 "和 "更改 DNA "旁边的"？"按钮描述了以编程方式修改角色的步骤。