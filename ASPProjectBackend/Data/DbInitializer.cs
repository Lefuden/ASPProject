using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using ASPProjectBackend.Services;
using Newtonsoft.Json;

namespace ASPProjectBackend.Data;

public static class DbInitializer
{
    public static async Task Init(ApplicationDbContext context, ApiServices api)
    {
        if (context.Games.Any())
        {
            return;
        }

        int[] appIds = [2139460, 1245620, 431960, 271590];


        foreach (var appId in appIds)
        {
            var game = await CreateGameObjFromJson(appId);
            if (game != null)
            {
                await context.AddAsync(game);
            }
        }
        await context.SaveChangesAsync();
    }
    public static string InitializeDbFromSteamApi(int appId)
    {
        return appId switch
        {
            2139460 => @"{
            ""2139460"": {
                ""success"": true,
                ""data"": {
                    ""type"": ""game"",
                    ""name"": ""Once Human"",
                    ""steam_appid"": 2139460,
                    ""required_age"": 0,
                    ""is_free"": true,
                    ""detailed_description"": ""<h1>Join our Discord!</h1><p><a href=\""https://steamcommunity.com/linkfilter/?u=https%3A%2F%2Fdiscord.gg%2Foncehuman\"" target=\""_blank\"" rel=\"" noopener\""  ><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/discord引流.jpg?t=1720769375\"" /></a></p><br><h1>About the Game</h1>The apocalypse changed everything. Human, animal, plant… all are infested by an alien creature – Stardust. As a Meta-Human, you can survive the contamination and use the power of Stardust. Play alone or join others to fight, build and explore. When the world is in chaos, you are our last hope.<h2 class=\""bb_tag\""><strong>Survive in the wilderness</strong></h2>You wake up in the middle of nowhere. You'll have to brace yourself for the cruelty of nature (from monsters to lack of food); however, Stardust's influence does not restrict to living things, it also affects the soil and water. Eating polluted food and drinking dirty water will reduce your Sanity. When your Sanity drops, your max HP would drop accordingly. To eat or not to eat, it's a question.<br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF1-开放世界_末日.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Fight against monsters</strong></h2>Battle numerous enemies that are once human, and challenge bosses from another dimension to gain powerful items and ease Stardust pollution. You are not only fighting for yourself, but also fighting for the survivors. <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF2-PVE.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Customize weapons</strong></h2>With about 100 gun blueprints divided into seven categories for you to collect and craft, every loot grants you something new. Did I mention accessories and gun perks? Right, they are the heroes here. If our current weapon cannot satisfy your need, you can add different parts and perks, upgrade your firearm to your heart's content.  <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF3-枪械武器装备（英）.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Build territory</strong></h2>Use Territory Core to build a house of your own. You can keep a practical style, jamming everything needed in a small room; or you can design a townhouse with a patio, kitchen, garage… The best part is, you can relocate your territory any time you want! <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF4-基地建设.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Find out the truth</strong></h2>Delve into the truth of Stardust, find out where it came from, and what it wants. In the journey of seeking truth, you may feel alone, but you are never alone. There are several factions in the world, some can be violent and hostile, others might be friendly and helpful. Explore human settlements to learn their stories or exterminate bosses without leaving a name for survivors to praise, the choices are yours.<br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF5-大型多人在线.gif?t=1720769375\"" />"",
                    ""about_the_game"": ""The apocalypse changed everything. Human, animal, plant… all are infested by an alien creature – Stardust. As a Meta-Human, you can survive the contamination and use the power of Stardust. Play alone or join others to fight, build and explore. When the world is in chaos, you are our last hope.<h2 class=\""bb_tag\""><strong>Survive in the wilderness</strong></h2>You wake up in the middle of nowhere. You'll have to brace yourself for the cruelty of nature (from monsters to lack of food); however, Stardust's influence does not restrict to living things, it also affects the soil and water. Eating polluted food and drinking dirty water will reduce your Sanity. When your Sanity drops, your max HP would drop accordingly. To eat or not to eat, it's a question.<br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF1-开放世界_末日.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Fight against monsters</strong></h2>Battle numerous enemies that are once human, and challenge bosses from another dimension to gain powerful items and ease Stardust pollution. You are not only fighting for yourself, but also fighting for the survivors. <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF2-PVE.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Customize weapons</strong></h2>With about 100 gun blueprints divided into seven categories for you to collect and craft, every loot grants you something new. Did I mention accessories and gun perks? Right, they are the heroes here. If our current weapon cannot satisfy your need, you can add different parts and perks, upgrade your firearm to your heart's content.  <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF3-枪械武器装备（英）.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Build territory</strong></h2>Use Territory Core to build a house of your own. You can keep a practical style, jamming everything needed in a small room; or you can design a townhouse with a patio, kitchen, garage… The best part is, you can relocate your territory any time you want! <br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF4-基地建设.gif?t=1720769375\"" /><h2 class=\""bb_tag\""><strong>Find out the truth</strong></h2>Delve into the truth of Stardust, find out where it came from, and what it wants. In the journey of seeking truth, you may feel alone, but you are never alone. There are several factions in the world, some can be violent and hostile, others might be friendly and helpful. Explore human settlements to learn their stories or exterminate bosses without leaving a name for survivors to praise, the choices are yours.<br><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/extras/GIF5-大型多人在线.gif?t=1720769375\"" />"",
                    ""short_description"": ""Once Human is a multiplayer open-world survival game set in a strange, post-apocalyptic future. Unite with friends to fight monstrous enemies, uncover secret plots, compete for resources, and build your own territory. Once, you were merely human. Now, you have the power to remake the world."",
                    ""supported_languages"": ""English<strong>*</strong>, Simplified Chinese<strong>*</strong>, French, German, Japanese, Korean, Traditional Chinese<br><strong>*</strong>languages with full audio support"",
                    ""header_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/header.jpg?t=1720769375"",
                    ""capsule_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/capsule_231x87.jpg?t=1720769375"",
                    ""capsule_imagev5"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2139460/capsule_184x69.jpg?t=1720769375"",
                    ""website"": ""https://t.co/gRX2BR4tj9"",
                    ""pc_requirements"": {
                        ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> Windows 10 64-bit Operating System<br></li><li><strong>Processor:</strong> Intel Core i5-4460<br></li><li><strong>Memory:</strong> 8 GB RAM<br></li><li><strong>Graphics:</strong> Nvidia GTX 750ti 4G / AMD Radeon RX550<br></li><li><strong>DirectX:</strong> Version 11<br></li><li><strong>Network:</strong> Broadband Internet connection<br></li><li><strong>Storage:</strong> 55 GB available space<br></li><li><strong>Additional Notes:</strong> SSD is highly recommended</li></ul>"",
                        ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> Windows 10 64-bit Operating System<br></li><li><strong>Processor:</strong> Intel Core i7-7700<br></li><li><strong>Memory:</strong> 16 GB RAM<br></li><li><strong>Graphics:</strong> Nvidia GTX 1060 6G / AMD Radeon RX 580 2304SP / Intel ARC A380<br></li><li><strong>DirectX:</strong> Version 11<br></li><li><strong>Network:</strong> Broadband Internet connection<br></li><li><strong>Storage:</strong> 55 GB available space<br></li><li><strong>Additional Notes:</strong> SSD is highly recommended</li></ul>""
                    },
                    ""mac_requirements"": [],
                    ""linux_requirements"": [],
                    ""legal_notice"": ""©1997-2022 NetEase, lnc. All Rights Reserved."",
                    ""genres"": [
                        {
                            ""id"": ""1"",
                            ""description"": ""Action""
                        },
                        {
                            ""id"": ""25"",
                            ""description"": ""Adventure""
                        },
                        {
                            ""id"": ""3"",
                            ""description"": ""RPG""
                        },
                        {
                            ""id"": ""28"",
                            ""description"": ""Simulation""
                        },
                        {
                            ""id"": ""2"",
                            ""description"": ""Strategy""
                        },
                        {
                            ""id"": ""37"",
                            ""description"": ""Free to Play""
                        }
                    ],
                    ""release_date"": {
                        ""coming_soon"": false,
                        ""date"": ""9 Jul, 2024""
                    }
                }
            }
        }",
            1245620 => @"{
""1245620"": {
        ""success"": true,
        ""data"": {
            ""type"": ""game"",
            ""name"": ""ELDEN RING"",
            ""steam_appid"": 1245620,
            ""required_age"": ""16"",
            ""is_free"": false,
            ""controller_support"": ""full"",
            ""dlc"": [
                2778590,
                2778580
            ],
            ""detailed_description"": ""<h1>ELDEN RING Shadow of the Erdtree Edition</h1><p><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/extras/ER_SHADOW-OF-THE-ERDTREE-EDITION_EN.gif?t=1720627962\"" /><br>ELDEN RING Shadow of the Erdtree Edition includes:<br><ul class=\""bb_ul\""><li>ELDEN RING<br></li><li>ELDEN RING Shadow of the Erdtree expansion</li></ul></p><br><h1>ELDEN RING Shadow of the Erdtree Deluxe Edition</h1><p><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/extras/ER_SHADOW-OF-THE-ERDTREE-DELUXE-EDITION_EN.gif?t=1720627962\"" /><br>ELDEN RING Shadow of the Erdtree Deluxe Edition includes:<br><ul class=\""bb_ul\""><li>ELDEN RING<br></li><li>ELDEN RING Shadow of the Erdtree expansion<br></li><li>ELDEN RING Digital Artbook &amp; Original Soundtrack<br></li><li>ELDEN RING Shadow of the Erdtree Artbook &amp; Soundtrack</li></ul></p><br><h1>About the Game</h1><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/extras/ER_Steam_Gif_616x260.gif?t=1720627962\"" /><br><br>THE NEW FANTASY ACTION RPG.<br>Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.<h2 class=\""bb_tag\"">• A Vast World Full of Excitement</h2>A vast world where open fields with a variety of situations and huge dungeons with complex and three-dimensional designs are seamlessly connected. As you explore, the joy of discovering unknown and overwhelming threats await you, leading to a high sense of accomplishment.<h2 class=\""bb_tag\"">• Create your Own Character</h2>In addition to customizing the appearance of your character, you can freely combine the weapons, armor, and magic that you equip. You can develop your character according to your play style, such as increasing your muscle strength to become a strong warrior, or mastering magic.<h2 class=\""bb_tag\"">• An Epic Drama Born from a Myth</h2>A multilayered story told in fragments. An epic drama in which the various thoughts of the characters intersect in the Lands Between.<h2 class=\""bb_tag\"">• Unique Online Play that Loosely Connects You to Others</h2>In addition to multiplayer, where you can directly connect with other players and travel together, the game supports a unique asynchronous online element that allows you to feel the presence of others."",
            ""about_the_game"": ""<img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/extras/ER_Steam_Gif_616x260.gif?t=1720627962\"" /><br><br>THE NEW FANTASY ACTION RPG.<br>Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.<h2 class=\""bb_tag\"">• A Vast World Full of Excitement</h2>A vast world where open fields with a variety of situations and huge dungeons with complex and three-dimensional designs are seamlessly connected. As you explore, the joy of discovering unknown and overwhelming threats await you, leading to a high sense of accomplishment.<h2 class=\""bb_tag\"">• Create your Own Character</h2>In addition to customizing the appearance of your character, you can freely combine the weapons, armor, and magic that you equip. You can develop your character according to your play style, such as increasing your muscle strength to become a strong warrior, or mastering magic.<h2 class=\""bb_tag\"">• An Epic Drama Born from a Myth</h2>A multilayered story told in fragments. An epic drama in which the various thoughts of the characters intersect in the Lands Between.<h2 class=\""bb_tag\"">• Unique Online Play that Loosely Connects You to Others</h2>In addition to multiplayer, where you can directly connect with other players and travel together, the game supports a unique asynchronous online element that allows you to feel the presence of others."",
            ""short_description"": ""THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between."",
            ""supported_languages"": ""English<strong>*</strong>, French, Italian, German, Spanish - Spain, Japanese, Korean, Polish, Portuguese - Brazil, Russian, Simplified Chinese, Spanish - Latin America, Thai, Traditional Chinese<br><strong>*</strong>languages with full audio support"",
            ""reviews"": ""“Put a ring on it.”<br>10/10 – <a href=\""https://www.ign.com/articles/elden-ring-review\"" target=\""_blank\"" rel=\""\""  >IGN</a><br><br>“An unmissable open-world masterpiece.”<br>10/10 – <a href=\""https://steamcommunity.com/linkfilter/?u=https%3A%2F%2Fwww.gamingbible.co.uk%2Freviews%2Felden-ring-review-fromsoftwares-latest-is-a-modern-masterpiece-20220222%23%3A~%3Atext%3DElden%2520Ring%2520is%2520a%2520constantly%2Coff%2520to%2520an%2520incredible%2520start.\"" target=\""_blank\"" rel=\"" noopener\""  >Gaming Bible</a><br><br>“Exploration is jaw dropping.”<br>5/5 – <a href=\""https://steamcommunity.com/linkfilter/?u=https%3A%2F%2Fwww.gamesradar.com%2Felden-ring-review%2F\"" target=\""_blank\"" rel=\"" noopener\""  >Games Radar</a><br>"",
            ""header_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/header_alt_assets_2.jpg?t=1720627962"",
            ""capsule_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/capsule_231x87.jpg?t=1720627962"",
            ""capsule_imagev5"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1245620/capsule_184x69.jpg?t=1720627962"",
            ""website"": null,
            ""pc_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""><li>Requires a 64-bit processor and operating system<br></li><li><strong>OS:</strong> Windows 10<br></li><li><strong>Processor:</strong> INTEL CORE I5-8400 or AMD RYZEN 3 3300X<br></li><li><strong>Memory:</strong> 12 GB RAM<br></li><li><strong>Graphics:</strong> NVIDIA GEFORCE GTX 1060 3 GB or AMD RADEON RX 580 4 GB<br></li><li><strong>DirectX:</strong> Version 12<br></li><li><strong>Storage:</strong> 60 GB available space<br></li><li><strong>Sound Card:</strong> Windows Compatible Audio Device<br></li><li><strong>Additional Notes:</strong> </li></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""><li>Requires a 64-bit processor and operating system<br></li><li><strong>OS:</strong> Windows 10/11<br></li><li><strong>Processor:</strong> INTEL CORE I7-8700K or AMD RYZEN 5 3600X<br></li><li><strong>Memory:</strong> 16 GB RAM<br></li><li><strong>Graphics:</strong> NVIDIA GEFORCE GTX 1070 8 GB or AMD RADEON RX VEGA 56 8 GB<br></li><li><strong>DirectX:</strong> Version 12<br></li><li><strong>Storage:</strong> 60 GB available space<br></li><li><strong>Sound Card:</strong> Windows Compatible Audio Device<br></li><li><strong>Additional Notes:</strong> </li></ul>""
            },
            ""mac_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""></ul>""
            },
            ""linux_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""></ul>""
            },
            ""legal_notice"": ""ELDEN RING™ & ©BANDAI NAMCO Entertainment Inc. / ©2022 FromSoftware, Inc."",
            ""price_overview"": {
                ""currency"": ""EUR"",
                ""initial"": 5999,
                ""final"": 5999,
                ""discount_percent"": 0,
                ""initial_formatted"": """",
                ""final_formatted"": ""59,99€""
            },
            ""metacritic"": {
                ""score"": 94,
                ""url"": ""https://www.metacritic.com/game/pc/elden-ring?ftag=MCD-06-10aaa1f""
            },
            ""genres"": [
                {
                    ""id"": ""1"",
                    ""description"": ""Action""
                },
                {
                    ""id"": ""3"",
                    ""description"": ""RPG""
                }
            ],
            ""release_date"": {
                ""coming_soon"": false,
                ""date"": ""24 Feb, 2022""
            }
        }
    }
}",
            431960 => @"{
""431960"": {
        ""success"": true,
        ""data"": {
            ""type"": ""game"",
            ""name"": ""Wallpaper Engine"",
            ""steam_appid"": 431960,
            ""required_age"": 0,
            ""is_free"": false,
            ""dlc"": [
                1790230
            ],
            ""detailed_description"": ""Wallpaper Engine enables you to use live wallpapers on your Windows desktop. Various types of animated wallpapers are supported, including 3D and 2D animations, websites, videos and even certain applications. Choose an existing wallpaper or create your own and share it on the Steam Workshop! In addition to that, you can use the free Wallpaper Engine companion app for Android to transfer your favorite wallpapers to your Android mobile device and take your live wallpapers on the go.<br><br><strong>NEW:</strong> Use the free Android companion app to transfer your favorite wallpapers to your Android mobile device.<br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_features.png?t=1717097477\"" /><br><br><ul class=\""bb_ul\""><li>Bring your desktop wallpapers alive with realtime graphics, videos, applications or websites.<br></li><li>Use animated screensavers while you are away from your computer.<br></li><li>Personalize animated wallpapers with your favorite colors.<br></li><li>Use interactive wallpapers that can be controlled with your mouse.<br></li><li>Many aspect ratios and native resolutions supported including 16:9, 21:9, 16:10, 4:3.<br></li><li>Multi monitor environments are supported.<br></li><li>Wallpapers will pause while playing games to save performance.<br></li><li>Create your own animated wallpapers in the Wallpaper Engine Editor.<br></li><li>Animate new live wallpapers from basic images or import HTML or video files for the wallpaper.<br></li><li>Use the Steam Workshop to share and download wallpapers for free.<br></li><li>Wallpaper Engine can be used at the same time as any other Steam game or application.<br></li><li>Supported video formats: mp4, WebM, avi, m4v, mov, wmv (for local files, Workshop only allows mp4).<br></li><li>Use the free Android companion app to take your favorite scene and video wallpapers on the go.<br></li><li>Support for Razer Chroma and Corsair iCUE.</li></ul><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/partners.png?t=1717097477\"" /><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_performance.png?t=1717097477\"" /><h2 class=\""bb_tag\""></h2>Wallpaper Engine aims to deliver an entertaining experience while using as few system resources as possible. You can choose to automatically pause or completely stop the wallpaper while using another application or playing fullscreen (including borderless windowed mode) to not distract or hinder you while playing a game or working. Many options to tweak quality and performance allow you to make Wallpaper Engine fit your computer perfectly. As a general rule of thumb, 3D, 2D and video based wallpapers will perform best, while websites and applications will require more resources from your system. Having a dedicated GPU is highly recommended, but not required.<h2 class=\""bb_tag\""></h2><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_workshop.png?t=1717097477\"" /><h2 class=\""bb_tag\""></h2>Choose from over a million free wallpapers from the Steam Workshop with new wallpapers being uploaded every day! Can't find a wallpaper that fits your mood? Let your imagination go wild by using the Wallpaper Engine Editor to create your own animated wallpapers from images, videos, websites or applications. A large selection of presets and effects allow you to animate your own images and share them on the Steam Workshop or to just use them for yourself."",
            ""about_the_game"": ""Wallpaper Engine enables you to use live wallpapers on your Windows desktop. Various types of animated wallpapers are supported, including 3D and 2D animations, websites, videos and even certain applications. Choose an existing wallpaper or create your own and share it on the Steam Workshop! In addition to that, you can use the free Wallpaper Engine companion app for Android to transfer your favorite wallpapers to your Android mobile device and take your live wallpapers on the go.<br><br><strong>NEW:</strong> Use the free Android companion app to transfer your favorite wallpapers to your Android mobile device.<br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_features.png?t=1717097477\"" /><br><br><ul class=\""bb_ul\""><li>Bring your desktop wallpapers alive with realtime graphics, videos, applications or websites.<br></li><li>Use animated screensavers while you are away from your computer.<br></li><li>Personalize animated wallpapers with your favorite colors.<br></li><li>Use interactive wallpapers that can be controlled with your mouse.<br></li><li>Many aspect ratios and native resolutions supported including 16:9, 21:9, 16:10, 4:3.<br></li><li>Multi monitor environments are supported.<br></li><li>Wallpapers will pause while playing games to save performance.<br></li><li>Create your own animated wallpapers in the Wallpaper Engine Editor.<br></li><li>Animate new live wallpapers from basic images or import HTML or video files for the wallpaper.<br></li><li>Use the Steam Workshop to share and download wallpapers for free.<br></li><li>Wallpaper Engine can be used at the same time as any other Steam game or application.<br></li><li>Supported video formats: mp4, WebM, avi, m4v, mov, wmv (for local files, Workshop only allows mp4).<br></li><li>Use the free Android companion app to take your favorite scene and video wallpapers on the go.<br></li><li>Support for Razer Chroma and Corsair iCUE.</li></ul><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/partners.png?t=1717097477\"" /><br><br><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_performance.png?t=1717097477\"" /><h2 class=\""bb_tag\""></h2>Wallpaper Engine aims to deliver an entertaining experience while using as few system resources as possible. You can choose to automatically pause or completely stop the wallpaper while using another application or playing fullscreen (including borderless windowed mode) to not distract or hinder you while playing a game or working. Many options to tweak quality and performance allow you to make Wallpaper Engine fit your computer perfectly. As a general rule of thumb, 3D, 2D and video based wallpapers will perform best, while websites and applications will require more resources from your system. Having a dedicated GPU is highly recommended, but not required.<h2 class=\""bb_tag\""></h2><img src=\""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/extras/title_workshop.png?t=1717097477\"" /><h2 class=\""bb_tag\""></h2>Choose from over a million free wallpapers from the Steam Workshop with new wallpapers being uploaded every day! Can't find a wallpaper that fits your mood? Let your imagination go wild by using the Wallpaper Engine Editor to create your own animated wallpapers from images, videos, websites or applications. A large selection of presets and effects allow you to animate your own images and share them on the Steam Workshop or to just use them for yourself."",
            ""short_description"": ""Use stunning live wallpapers on your desktop. Animate your own images to create new wallpapers or import videos/websites and share them on the Steam Workshop!"",
            ""supported_languages"": ""English, German, Simplified Chinese, Polish, Portuguese - Brazil, French, Italian, Spanish - Spain, Finnish, Japanese, Korean, Swedish, Thai, Traditional Chinese, Turkish, Portuguese - Portugal, Russian, Danish, Czech, Arabic, Ukrainian, Indonesian, Persian"",
            ""header_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/header.jpg?t=1717097477"",
            ""capsule_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/capsule_231x87.jpg?t=1717097477"",
            ""capsule_imagev5"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/431960/capsule_184x69.jpg?t=1717097477"",
            ""website"": ""https://www.wallpaperengine.io"",
            ""pc_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> Windows 10, Windows 11<br></li><li><strong>Processor:</strong> 1.66 GHz Intel i5 or equivalent<br></li><li><strong>Memory:</strong> 1024 MB RAM<br></li><li><strong>Graphics:</strong> HD Graphics 4000 or above<br></li><li><strong>DirectX:</strong> Version 11<br></li><li><strong>Storage:</strong> 512 MB available space<br></li><li><strong>Additional Notes:</strong> Windows N versions require the 'Media Feature Pack' from Microsoft.</li></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> Windows 10, Windows 11<br></li><li><strong>Processor:</strong> 2.0 GHz Intel i7 or equivalent<br></li><li><strong>Memory:</strong> 2048 MB RAM<br></li><li><strong>Graphics:</strong> NVIDIA GeForce GTX 660, AMD HD7870, 2 GB VRAM or above<br></li><li><strong>DirectX:</strong> Version 11<br></li><li><strong>Storage:</strong> 1024 MB available space<br></li><li><strong>Additional Notes:</strong> Mobile App requires Android 8.1 or newer</li></ul>""
            },
            ""mac_requirements"": [],
            ""linux_requirements"": [],
            ""legal_notice"": ""Copyright © 2016-2024 Skutta Software GmbH"",
            ""price_overview"": {
                ""currency"": ""EUR"",
                ""initial"": 399,
                ""final"": 399,
                ""discount_percent"": 0,
                ""initial_formatted"": """",
                ""final_formatted"": ""3,99€""
            },
            ""genres"": [
                {
                    ""id"": ""4"",
                    ""description"": ""Casual""
                },
                {
                    ""id"": ""23"",
                    ""description"": ""Indie""
                },
                {
                    ""id"": ""51"",
                    ""description"": ""Animation & Modeling""
                },
                {
                    ""id"": ""53"",
                    ""description"": ""Design & Illustration""
                },
                {
                    ""id"": ""55"",
                    ""description"": ""Photo Editing""
                },
                {
                    ""id"": ""57"",
                    ""description"": ""Utilities""
                }
            ],
            ""release_date"": {
                ""coming_soon"": false,
                ""date"": ""Nov 2018""
            }
        }
    }
}",
            271590 => @"{
""271590"": {
        ""success"": true,
        ""data"": {
            ""type"": ""game"",
            ""name"": ""Grand Theft Auto V"",
            ""steam_appid"": 271590,
            ""required_age"": ""17"",
            ""is_free"": false,
            ""controller_support"": ""full"",
            ""dlc"": [
                771300
            ],
            ""detailed_description"": ""When a young street hustler, a retired bank robber and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.<br> <br>Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second. <br> <br>The game offers players a huge range of PC-specific customization options, including over 25 separate configurable settings for texture quality, shaders, tessellation, anti-aliasing and more, as well as support and extensive customization for mouse and keyboard controls. Additional options include a population density slider to control car and pedestrian traffic, as well as dual and triple monitor support, 3D compatibility, and plug-and-play controller support.  <br> <br>Grand Theft Auto V for PC also includes Grand Theft Auto Online, with support for 30 players and two spectators. Grand Theft Auto Online for PC will include all existing gameplay upgrades and Rockstar-created content released since the launch of Grand Theft Auto Online, including Heists and Adversary modes.<br> <br>The PC version of Grand Theft Auto V and Grand Theft Auto Online features First Person Mode, giving players the chance to explore the incredibly detailed world of Los Santos and Blaine County in an entirely new way.<br> <br>Grand Theft Auto V for PC also brings the debut of the Rockstar Editor, a powerful suite of creative tools to quickly and easily capture, edit and share game footage from within Grand Theft Auto V and Grand Theft Auto Online. The Rockstar Editor’s Director Mode allows players the ability to stage their own scenes using prominent story characters, pedestrians, and even animals to bring their vision to life. Along with advanced camera manipulation and editing effects including fast and slow motion, and an array of camera filters, players can add their own music using songs from GTAV radio stations, or dynamically control the intensity of the game’s score. Completed videos can be uploaded directly from the Rockstar Editor to YouTube and the Rockstar Games Social Club for easy sharing.  <br> <br>Soundtrack artists The Alchemist and Oh No return as hosts of the new radio station, The Lab FM. The station features new and exclusive music from the production duo based on and inspired by the game’s original soundtrack. Collaborating guest artists include Earl Sweatshirt, Freddie Gibbs, Little Dragon, Killer Mike, Sam Herring from Future Islands, and more. Players can also discover Los Santos and Blaine County while enjoying their own music through Self Radio, a new radio station that will host player-created custom soundtracks.<br><br>Special access content requires Rockstar Games Social Club account. Visit <a href=\""https://steamcommunity.com/linkfilter/?u=http%3A%2F%2Frockstargames.com%2Fv%2Fbonuscontent\"" target=\""_blank\"" rel=\"" noopener\""  >http://rockstargames.com/v/bonuscontent</a> for details."",
            ""about_the_game"": ""When a young street hustler, a retired bank robber and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.<br> <br>Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second. <br> <br>The game offers players a huge range of PC-specific customization options, including over 25 separate configurable settings for texture quality, shaders, tessellation, anti-aliasing and more, as well as support and extensive customization for mouse and keyboard controls. Additional options include a population density slider to control car and pedestrian traffic, as well as dual and triple monitor support, 3D compatibility, and plug-and-play controller support.  <br> <br>Grand Theft Auto V for PC also includes Grand Theft Auto Online, with support for 30 players and two spectators. Grand Theft Auto Online for PC will include all existing gameplay upgrades and Rockstar-created content released since the launch of Grand Theft Auto Online, including Heists and Adversary modes.<br> <br>The PC version of Grand Theft Auto V and Grand Theft Auto Online features First Person Mode, giving players the chance to explore the incredibly detailed world of Los Santos and Blaine County in an entirely new way.<br> <br>Grand Theft Auto V for PC also brings the debut of the Rockstar Editor, a powerful suite of creative tools to quickly and easily capture, edit and share game footage from within Grand Theft Auto V and Grand Theft Auto Online. The Rockstar Editor’s Director Mode allows players the ability to stage their own scenes using prominent story characters, pedestrians, and even animals to bring their vision to life. Along with advanced camera manipulation and editing effects including fast and slow motion, and an array of camera filters, players can add their own music using songs from GTAV radio stations, or dynamically control the intensity of the game’s score. Completed videos can be uploaded directly from the Rockstar Editor to YouTube and the Rockstar Games Social Club for easy sharing.  <br> <br>Soundtrack artists The Alchemist and Oh No return as hosts of the new radio station, The Lab FM. The station features new and exclusive music from the production duo based on and inspired by the game’s original soundtrack. Collaborating guest artists include Earl Sweatshirt, Freddie Gibbs, Little Dragon, Killer Mike, Sam Herring from Future Islands, and more. Players can also discover Los Santos and Blaine County while enjoying their own music through Self Radio, a new radio station that will host player-created custom soundtracks.<br><br>Special access content requires Rockstar Games Social Club account. Visit <a href=\""https://steamcommunity.com/linkfilter/?u=http%3A%2F%2Frockstargames.com%2Fv%2Fbonuscontent\"" target=\""_blank\"" rel=\"" noopener\""  >http://rockstargames.com/v/bonuscontent</a> for details."",
            ""short_description"": ""Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second."",
            ""supported_languages"": ""English<strong>*</strong>, French, Italian, German, Spanish - Spain, Korean, Polish, Portuguese - Brazil, Russian, Traditional Chinese, Japanese, Simplified Chinese, Spanish - Latin America<br><strong>*</strong>languages with full audio support"",
            ""header_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/271590/header.jpg?t=1720472998"",
            ""capsule_image"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/271590/capsule_231x87.jpg?t=1720472998"",
            ""capsule_imagev5"": ""https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/271590/capsule_184x69.jpg?t=1720472998"",
            ""website"": ""http://www.rockstargames.com/V/"",
            ""pc_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""><li>Requires a 64-bit processor and operating system<br></li><li><strong>OS:</strong> Windows 10 64 Bit<br></li><li><strong>Processor:</strong> Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz<br></li><li><strong>Memory:</strong> 4 GB RAM<br></li><li><strong>Graphics:</strong> NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11)<br></li><li><strong>Storage:</strong> 120 GB available space<br></li><li><strong>Sound Card:</strong> 100% DirectX 10 compatible<br></li><li><strong>Additional Notes:</strong> Over time downloadable content and programming changes will change the system requirements for this game.  Please refer to your hardware manufacturer and <a href=\""https://steamcommunity.com/linkfilter/?u=http%3A%2F%2Fwww.rockstargames.com%2Fsupport\"" target=\""_blank\"" rel=\"" noopener\""  >www.rockstargames.com/support</a> for current compatibility information. Some system components such as mobile chipsets, integrated, and AGP graphics cards may be incompatible. Unlisted specifications may not be supported by publisher.     Other requirements:  Installation and online play requires log-in to Rockstar Games Social Club (13+) network; internet connection required for activation, online play, and periodic entitlement verification; software installations required including Rockstar Games Social Club platform, DirectX , Chromium, and Microsoft Visual C++ 2008 sp1 Redistributable Package, and authentication software that recognizes certain hardware attributes for entitlement, digital rights management, system, and other support purposes.     SINGLE USE SERIAL CODE REGISTRATION VIA INTERNET REQUIRED; REGISTRATION IS LIMITED TO ONE ROCKSTAR GAMES SOCIAL CLUB ACCOUNT (13+) PER SERIAL CODE; ONLY ONE PC LOG-IN ALLOWED PER SOCIAL CLUB ACCOUNT AT ANY TIME; SERIAL CODE(S) ARE NON-TRANSFERABLE ONCE USED; SOCIAL CLUB ACCOUNTS ARE NON-TRANSFERABLE.  Partner Requirements:  Please check the terms of service of this site before purchasing this software.</li></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""><li>Requires a 64-bit processor and operating system<br></li><li><strong>OS:</strong> Windows 10 64 Bit<br></li><li><strong>Processor:</strong> Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs)<br></li><li><strong>Memory:</strong> 8 GB RAM<br></li><li><strong>Graphics:</strong> NVIDIA GTX 660 2GB / AMD HD 7870 2GB<br></li><li><strong>Storage:</strong> 120 GB available space<br></li><li><strong>Sound Card:</strong> 100% DirectX 10 compatible</li></ul>""
            },
            ""mac_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""></ul>""
            },
            ""linux_requirements"": {
                ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""></ul>"",
                ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""></ul>""
            },
            ""legal_notice"": ""©2008 - 2015 Rockstar Games, Inc. Rockstar Games, Rockstar North, Grand Theft Auto, the GTA Five, and the Rockstar Games R* marks and logos are trademarks and/or registered trademarks of Take-Two Interactive Software, Inc. in the U.S.A. and/or foreign countries.   Dolby and the double-D symbols are trademarks of Dolby Laboratories. Uses Bink Video. Copyright © 1997-2012 by  RAD Game Tools, Inc. euphoria motion synthesis technology provided by NaturalMotion. euphoria code is (c) NaturalMotion 2008. \""NaturalMotion\"", \""euphoria\"" and the NaturalMotion and euphoria logos are trademarks of NaturalMotion. Used under license. This software product includes Autodesk® Scaleform® software, © 2013 Autodesk, Inc.  All rights reserved The ratings icon is a trademark of the Entertainment Software Association. All other marks and trademarks are properties of their respective owners.  All rights reserved.    <br />\r\n<br />\r\nSoftware license terms in game and www.rockstargames.com/eula; online account terms at www.rockstargames.com/socialclub <br />\r\n<br />\r\nViolation of EULA, Code of Conduct, or other policies may result in restriction or termination of access to game or online account. Player data transfer subject to certain limits and requirements, see www.rockstargames.com/gtaonline/charactertransfer for details. For customer& technical support visit www.rockstargames.com/support<br />\r\n<br />\r\nNon-transferable access to special features such as exclusive/unlockable/downloadable/online  content/services/functions, such as multiplayer services or bonus content, may require single-use serial code, additional fee, and/or online account registration (13+).  Access to special features may require internet connection, may not be available to all users, and may, upon 30 days notice, be terminated, modified, or offered under different terms.  Unauthorized copying, reverse engineering, transmission, public performance, rental, pay for play, or circumvention of copy protection is strictly prohibited.<br />\r\n<br />\r\nThe content of this video game is purely fictional, is not intended to represent or depict any actual event, person, or entity, and any such similarities are purely coincidental.  The makers and publishers of this video game do not in any way endorse, condone or encourage engaging in any conduct depicted in this video game.<br />\r\n<br />\r\nRockstar Games, 622 Broadway, New York, NY, 10012  <br />\r\nT2 Take Two Interactive<br />\r\n<br />\r\nFor information about online services, fees, restrictions, or software license terms that may apply to this game, please visit  www.rockstargames.com"",
            ""ext_user_account_notice"": ""Rockstar Games (Supports Linking to Steam Account)"",
            ""metacritic"": {
                ""score"": 96,
                ""url"": ""https://www.metacritic.com/game/pc/grand-theft-auto-v?ftag=MCD-06-10aaa1f""
            },
            ""genres"": [
                {
                    ""id"": ""1"",
                    ""description"": ""Action""
                },
                {
                    ""id"": ""25"",
                    ""description"": ""Adventure""
                }
            ],
            ""release_date"": {
                ""coming_soon"": false,
                ""date"": ""13 Apr, 2015""
            }
        }
    }
}",
            _ => @"{
    POOP: { POOP : POOP }
}"
        };
    }


    public static async Task<Game> CreateGameObjFromJson(int appId)
    {
        using var client = new HttpClient();
        var random = new Random();
        //var response = await client.GetStringAsync($"https://store.steampowered.com/api/appdetails?appids={appId}&cc=se&filters=basic,price_overview,metacritic,genres,release_date");
        var response = InitializeDbFromSteamApi(appId);

        var settings = new JsonSerializerSettings();
        //settings.Converters.Add(new AppDetailsResponseConverter());
        var data = JsonConvert.DeserializeObject<AppDetailsContainer>(response);
        if (data == null)
        {
            return default;
        }

        var gameData = data.Data;

        return new Game
        {
            Type = gameData?.Type ?? "",
            Name = gameData?.Name ?? "",
            SteamAppId = gameData!.SteamAppid,
            RequiredAge = gameData?.RequiredAge,
            IsFree = gameData?.IsFree,
            DetailedDescription = gameData?.DetailedDescription ?? "",
            AboutTheGame = gameData?.AboutTheGame ?? "",
            ShortDescription = gameData?.ShortDescription ?? "",
            SupportedLanguages = gameData?.SupportedLanguages ?? "",
            HeaderImage = gameData?.HeaderImage ?? "",
            Website = gameData?.Website ?? "",
            PcRequirements = gameData?.PcRequirements != null ? JsonConvert.SerializeObject(gameData.PcRequirements) : "",
            MacRequirements = gameData?.MacRequirements != null ? JsonConvert.SerializeObject(gameData.MacRequirements) : "",
            LinuxRequirements = gameData?.LinuxRequirements != null ? JsonConvert.SerializeObject(gameData.LinuxRequirements) : "",
            Developers = gameData?.Developers != null ? string.Join(", ", gameData.Developers) : string.Empty,
            Publishers = gameData?.Publishers != null ? string.Join(", ", gameData.Publishers) : string.Empty,
            Categories = gameData?.Categories != null ? string.Join(", ", gameData.Categories.Select(c => c.Description)) : string.Empty,
            Genres = gameData?.Genres != null ? string.Join(", ", gameData.Genres.Select(g => g.Description)) : string.Empty,
            Screenshots = gameData?.Screenshots != null ? string.Join(", ", gameData.Screenshots.Select(s => s.PathFull)) : string.Empty,
            Movies = gameData?.Movies != null ? string.Join(", ", gameData.Movies.Select(m => m.Name)) : string.Empty,
            Platforms = gameData?.Platforms != null ? $"Windows: {gameData.Platforms.Windows}, Mac: {gameData.Platforms.Mac}, Linux: {gameData.Platforms.Linux}" : string.Empty,
            MetacriticScore = gameData?.Metacritic?.Score,
            MetacriticUrl = gameData?.Metacritic?.Url ?? "",
            TotalRecommendations = gameData?.Recommendations?.Total ?? 0,
            TotalAchievements = gameData?.Achievements?.Total ?? 0,
            ReleaseDate = gameData?.ReleaseDate != null ? JsonConvert.SerializeObject(gameData.ReleaseDate.Date) : "",
            ComingSoon = gameData?.ReleaseDate?.ComingSoon,
            SupportInfo = gameData?.SupportInfo != null ? $"{gameData.SupportInfo.Url}, {gameData.SupportInfo.Email}" : "",
            Background = gameData?.Background ?? "",
            ContentDescriptors = gameData?.ContentDescriptors != null ? string.Join(", ", gameData.ContentDescriptors.Ids) : string.Empty,
            InitialPrice = gameData?.PriceOverview?.Initial ?? 0,
            DiscountPercent = gameData?.PriceOverview?.DiscountPercent ?? 0,
            Stock = (byte)random.Next(5, 73)
        };
    }
}