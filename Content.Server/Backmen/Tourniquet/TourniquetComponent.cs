using Content.Shared.Body.Part;
using Robust.Shared.Audio;

namespace Content.Server.Backmen.Tourniquet;

/// <summary>
/// This is used for tourniquet. Yes
/// </summary>
[RegisterComponent]
public sealed partial class TourniquetComponent : Component
{
    [ViewVariables(VVAccess.ReadOnly)]
    public EntityUid? BodyPartTourniqueted;

    /// <summary>
    /// How long it takes to put the tourniquet on.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField]
    public float Delay = 5f;

    /// <summary>
    /// How long it takes to take the tourniquet off.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField]
    public float RemoveDelay = 7f;

    [DataField, ViewVariables(VVAccess.ReadOnly)]
    public List<BodyPartType> BlockedBodyParts = new();

    /// <summary>
    ///     Sound played on healing begin
    /// </summary>
    [DataField("putOnSound")]
    public SoundSpecifier? TourniquetPutOnSound;

    /// <summary>
    ///     Sound played on healing end
    /// </summary>
    [DataField("putOffSound")]
    public SoundSpecifier? TourniquetPutOffSound;
}
