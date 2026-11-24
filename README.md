# purchasely-package
## Android native SDK 6.x (since 2026-10)

`Native/Android/purchasely-lib-release.aar` is built from
[PurchaselyUnityBridgeAndroidLibrary](https://github.com/EdokiAcademy/PurchaselyUnityBridgeAndroidLibrary)
against **io.purchasely 6.2.0** (Google Play Billing 8.3.0). The `io.purchasely:core` /
`google-play` runtime itself is injected into the Unity Gradle project by
`EdokiPurchasely/Editor/AndroidPostProcess.cs`; keep that version and the AAR's `compileOnly`
version identical.

Behaviour differences on Android (the C# API did not change, iOS still runs the 5.7.x pod):

- `PresentSubscriptions()` is a no-op: Purchasely 6 removed the built-in subscriptions screen.
- `PresentPresentationForProduct/ForPlan` fall back to the presentation / placement id they carry
  (product/plan targeting was removed from the SDK).
- `IsEligibleForIntroOffer` maps to `PLYPlan.isEligibleToOffer()`.
- `SetIsReadyToOpenDeeplink` maps to `Purchasely.allowDeeplink`; the SDK is started with it `false`
  to keep the v5 behaviour (v6 defaults to `true`).
- `RunningMode.Full` maps to `PLYRunningMode.Full`; every other value maps to `Observer`
  (`PaywallObserver` was renamed, and the v6 default is `Observer`).
- Every paywall is built with `displayBackButton(false)` (bridge `PurchaselyBridge.buildPresentation`).
  v6 defaults it to `true` and, on a Screen that defines a back button, draws a black arrow over a
  top-left close button (MM-937). Undo = revert the bridge commit and put the previous AAR back.
