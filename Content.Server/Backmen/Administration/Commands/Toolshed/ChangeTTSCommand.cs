﻿using System.Linq;
using Content.Server.Administration;
using Content.Server.Backmen.Disease;
using Content.Server.Corvax.TTS;
using Content.Server.Humanoid;
using Content.Shared.Administration;
using Content.Shared.Backmen.Disease;
using Content.Shared.Corvax.TTS;
using Content.Shared.Humanoid;
using Robust.Shared.Prototypes;
using Robust.Shared.Toolshed;
using Robust.Shared.Toolshed.TypeParsers;

namespace Content.Server.Backmen.Administration.Commands.Toolshed;

[ToolshedCommand, AdminCommand(AdminFlags.Fun)]
public sealed class ChangeTTSCommand : ToolshedCommand
{
    private HumanoidAppearanceSystem? _appearanceSystem;

    [CommandImplementation]
    public EntityUid? ChangeTTS(
        [PipedArgument] EntityUid input,
        [CommandArgument] ProtoId<TTSVoicePrototype> prototype
    )
    {
        if (EntityManager.TryGetComponent<HumanoidAppearanceComponent>(input, out var humanoidAppearanceComponent))
        {
            _appearanceSystem ??= GetSys<HumanoidAppearanceSystem>();

            _appearanceSystem.SetTTSVoice(input, prototype.Id, humanoid: humanoidAppearanceComponent);
            return input;
        }

        var tts = EnsureComp<TTSComponent>(input);
        tts.VoicePrototypeId = prototype.Id;

        return input;
    }

    [CommandImplementation]
    public IEnumerable<EntityUid> ChangeTTS(
        [PipedArgument] IEnumerable<EntityUid> input,
        [CommandArgument] ProtoId<TTSVoicePrototype> prototype
    )
        => input.Select(x => ChangeTTS(x, prototype)).Where(x => x is not null).Select(x => (EntityUid) x!);
}
