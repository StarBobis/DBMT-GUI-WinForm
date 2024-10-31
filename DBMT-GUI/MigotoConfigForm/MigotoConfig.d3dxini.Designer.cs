using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMT_GUI
{
    partial class MigotoConfig
    {


        class D3DXConfig
        {
            List<string> d3dxiniLineList = new List<string>();

            private void InitializeIncludeSection()
            {
                this.d3dxiniLineList.Add("[Include]");
                this.d3dxiniLineList.Add("include_recursive = Mods");
                this.d3dxiniLineList.Add("include_recursive = Core");
                this.d3dxiniLineList.Add("exclude_recursive = DISABLED*");
            }

            private void InitializeLoggingSection()
            {
                this.d3dxiniLineList.Add("[Logging]");
                this.d3dxiniLineList.Add("calls=1");
                this.d3dxiniLineList.Add("input=1");
                this.d3dxiniLineList.Add("debug=0");
                this.d3dxiniLineList.Add("unbuffered=0");
                this.d3dxiniLineList.Add("force_cpu_affinity=0");
                this.d3dxiniLineList.Add("convergence=1");
                this.d3dxiniLineList.Add("separation=1");
                this.d3dxiniLineList.Add("debug_locks=0");
                this.d3dxiniLineList.Add("crash=0");
            }

            private void InitializeConstantsSection()
            {
                this.d3dxiniLineList.Add("[Constants]");

            }

            private void InitializeHuntingSection()
            {
                this.d3dxiniLineList.Add("[Hunting]");
                this.d3dxiniLineList.Add("hunting=2");
                this.d3dxiniLineList.Add("marking_mode=skip");
                this.d3dxiniLineList.Add("next_marking_mode = no_modifiers VK_DECIMAL VK_NUMPAD0");
                this.d3dxiniLineList.Add("marking_actions = hlsl asm clipboard regex stereo_snapshot snapshot_if_pink");

                this.d3dxiniLineList.Add("previous_pixelshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD1");
                this.d3dxiniLineList.Add("next_pixelshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD2");
                this.d3dxiniLineList.Add("mark_pixelshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD3");

                this.d3dxiniLineList.Add("previous_vertexshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD4");
                this.d3dxiniLineList.Add("next_vertexshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD5");
                this.d3dxiniLineList.Add("mark_vertexshader = no_modifiers NO_VK_DECIMAL VK_NUMPAD6");

                this.d3dxiniLineList.Add("previous_indexbuffer = no_modifiers NO_VK_DECIMAL VK_NUMPAD7");
                this.d3dxiniLineList.Add("next_indexbuffer = no_modifiers NO_VK_DECIMAL VK_NUMPAD8");
                this.d3dxiniLineList.Add("mark_indexbuffer = no_modifiers NO_VK_DECIMAL VK_NUMPAD9");

                this.d3dxiniLineList.Add("previous_vertexbuffer = no_modifiers NO_VK_DECIMAL VK_DIVIDE");
                this.d3dxiniLineList.Add("next_vertexbuffer = no_modifiers NO_VK_DECIMAL VK_MULTIPLY");
                this.d3dxiniLineList.Add("mark_vertexbuffer = no_modifiers NO_VK_DECIMAL VK_SUBTRACT");

                this.d3dxiniLineList.Add(";previous_rendertarget = no_modifiers VK_INSERT");
                this.d3dxiniLineList.Add(";next_rendertarget = no_modifiers VK_HOME");
                this.d3dxiniLineList.Add(";mark_rendertarget = no_modifiers VK_PAGEUP");

                this.d3dxiniLineList.Add("previous_computeshader = no_modifiers VK_DECIMAL VK_NUMPAD1");
                this.d3dxiniLineList.Add("next_computeshader = no_modifiers VK_DECIMAL VK_NUMPAD2");
                this.d3dxiniLineList.Add("mark_computeshader = no_modifiers VK_DECIMAL VK_NUMPAD3");

                this.d3dxiniLineList.Add("previous_geometryshader = no_modifiers VK_DECIMAL VK_NUMPAD4");
                this.d3dxiniLineList.Add("next_geometryshader = no_modifiers VK_DECIMAL VK_NUMPAD5");
                this.d3dxiniLineList.Add("mark_geometryshader = no_modifiers VK_DECIMAL VK_NUMPAD6");

                this.d3dxiniLineList.Add("previous_domainshader = no_modifiers VK_DECIMAL VK_NUMPAD7");
                this.d3dxiniLineList.Add("next_domainshader = no_modifiers VK_DECIMAL VK_NUMPAD8");
                this.d3dxiniLineList.Add("mark_domainshader = no_modifiers VK_DECIMAL VK_NUMPAD9");

                this.d3dxiniLineList.Add("previous_hullshader = no_modifiers VK_DECIMAL VK_DIVIDE");
                this.d3dxiniLineList.Add("next_hullshader = no_modifiers VK_DECIMAL VK_MULTIPLY");
                this.d3dxiniLineList.Add("mark_hullshader = no_modifiers VK_DECIMAL VK_SUBTRACT");

                this.d3dxiniLineList.Add("done_hunting = NO_MODIFIERS NO_VK_DECIMAL VK_ADD");
                this.d3dxiniLineList.Add("take_screenshot = no_modifiers VK_SNAPSHOT");
                this.d3dxiniLineList.Add("reload_fixes = no_modifiers VK_F10");
                this.d3dxiniLineList.Add("toggle_hunting = no_modifiers NO_VK_DECIMAL VK_NUMPAD0");
                this.d3dxiniLineList.Add("reload_config = no_modifiers VK_F10");
                this.d3dxiniLineList.Add("wipe_user_config = ctrl alt no_shift VK_F10");
                this.d3dxiniLineList.Add("show_original = no_modifiers VK_F9");
                this.d3dxiniLineList.Add("monitor_performance = ctrl no_shift no_alt F9");
                this.d3dxiniLineList.Add("freeze_performance_monitor = no_ctrl shift no_alt F9");
                this.d3dxiniLineList.Add("monitor_performance_interval = 2.0");
                this.d3dxiniLineList.Add("repeat_rate=6");
                this.d3dxiniLineList.Add("verbose_overlay = 1");
                this.d3dxiniLineList.Add("analyse_frame = no_modifiers VK_F8");
                this.d3dxiniLineList.Add("analyse_options = mono dump_on_unmap dump_on_map dump_rt dump_tex dump_cb dump_vb dump_ib buf txt ");
            }


            private void InitializeSystemSection()
            {
                this.d3dxiniLineList.Add("[System]");
                this.d3dxiniLineList.Add("load_library_redirect=2");
                this.d3dxiniLineList.Add("check_foreground_window=1");
                this.d3dxiniLineList.Add("allow_check_interface=1");
                this.d3dxiniLineList.Add("allow_create_device=1");
                this.d3dxiniLineList.Add("allow_platform_update=1");
            }

            private void InitializeDeviceSection()
            {
                this.d3dxiniLineList.Add("[Device]");
                this.d3dxiniLineList.Add("upscaling = 0");
                this.d3dxiniLineList.Add("full_screen=0");
                this.d3dxiniLineList.Add("force_stereo=0");
                this.d3dxiniLineList.Add("get_resolution_from = swap_chain");
                this.d3dxiniLineList.Add("hide_cursor = 0");
            }

            private void InitializeStereoSection()
            {
                this.d3dxiniLineList.Add("[Stereo]");
                this.d3dxiniLineList.Add("automatic_mode=0");
                this.d3dxiniLineList.Add("unlock_separation=0");
                this.d3dxiniLineList.Add("unlock_convergence=0");
                this.d3dxiniLineList.Add("create_profile=0");
                this.d3dxiniLineList.Add("force_no_nvapi=0");

            }

            private void InitializeRenderingSection()
            {
                this.d3dxiniLineList.Add("[Rendering]");
                this.d3dxiniLineList.Add("shader_hash = 3dmigoto");
                this.d3dxiniLineList.Add("override_directory=ShaderFixes");
                this.d3dxiniLineList.Add("cache_directory=ShaderCache");
                this.d3dxiniLineList.Add("storage_directory=ShaderFromGame");
                this.d3dxiniLineList.Add("cache_shaders=0");
                this.d3dxiniLineList.Add("rasterizer_disable_scissor=0");
                this.d3dxiniLineList.Add("track_texture_updates=1");
                this.d3dxiniLineList.Add("stereo_params = 125");
                this.d3dxiniLineList.Add("ini_params = 120");
                this.d3dxiniLineList.Add("assemble_signature_comments = 1");
                this.d3dxiniLineList.Add("disassemble_undecipherable_custom_data = 1");
                this.d3dxiniLineList.Add("patch_assembly_cb_offsets = 1");
                this.d3dxiniLineList.Add("recursive_include = 1");
                this.d3dxiniLineList.Add("export_fixed=0");
                this.d3dxiniLineList.Add("export_shaders=0");
                this.d3dxiniLineList.Add("export_hlsl=0");
                this.d3dxiniLineList.Add("dump_usage=1");
                this.d3dxiniLineList.Add("fix_sv_position=0");

            }

            private void InitializeProfileSection()
            {
                this.d3dxiniLineList.Add("[Profile]");

            }

            private void InitializeBuiltinCommandListUnbindAllRenderTargetSection()
            {
                this.d3dxiniLineList.Add("[CommandListUnbindAllRenderTargets]");
                this.d3dxiniLineList.Add("run = BuiltInCommandListUnbindAllRenderTargets");
            }

            private void InitializePresentSection()
            {
                this.d3dxiniLineList.Add("[Present]");
            }

            public void InitializeStandardD3DXConfig(LoaderConfig loaderConfig)
            {
                InitializeIncludeSection();
                InitializeLoggingSection();
                InitializeConstantsSection();
                InitializeHuntingSection();
                InitializeSystemSection();

                //Loader部分手动填写
                this.d3dxiniLineList.Add("[Loader]");
                this.d3dxiniLineList.Add("target = " + loaderConfig.target);
                this.d3dxiniLineList.Add("module = " + loaderConfig.module);
                this.d3dxiniLineList.Add("require_admin = " + loaderConfig.require_admin);
                if (!string.IsNullOrEmpty(loaderConfig.launch))
                {
                    this.d3dxiniLineList.Add("launch = " + loaderConfig.launch);
                }
                if (!string.IsNullOrEmpty(loaderConfig.launch_args))
                {
                    this.d3dxiniLineList.Add("launch_args = " + loaderConfig.launch_args);
                }
                this.d3dxiniLineList.Add(";delay = 20");

                InitializeDeviceSection();
                InitializeStereoSection();
                InitializeRenderingSection();
                InitializeProfileSection();
                InitializeBuiltinCommandListUnbindAllRenderTargetSection();
                InitializePresentSection();
            }

            public void SaveToD3DXINI(string d3dxiniPath)
            {
                File.WriteAllLines(d3dxiniPath, this.d3dxiniLineList);
            }
        }


        class LoaderConfig
        {
            public string target = "";
            public string launch = "";
            public string launch_args = "";
            public string module = "d3d11.dll";
            public bool require_admin = true;
        }


    }


}
