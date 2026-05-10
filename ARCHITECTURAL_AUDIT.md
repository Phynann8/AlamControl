# Architectural Audit: AlamControl

**Date:** 2026-02-15
**Target:** `AlamControl` (VB.NET / Windows Forms)
**Auditor:** Principal Systems Architect

## 1) Executive Summary
**Architecture:** Desktop Monolith (VB.NET Windows Forms).
**Verdict:** **Legacy / End-of-Life.**
This is a legacy VB.NET application targeting .NET Framework 4.8. It uses a monolithic architecture with UI logic tightly coupled to business logic (likely inside `FrmMain.vb`). It appears to be a single-user desktop tool with a setup project for distribution.

## 2) Key Design Decisions & Analysis

### Technology Stack
- **Language:** VB.NET
- **Framework:** .NET Framework 4.8 (Windows Forms)
- **Deployment:** MSI Installer (`Setup.vdproj`)

### Data Architecture
- **Current:** Unknown (likely hardcoded paths or local file storage, given lack of `app.config` connection strings).
- **Risk:** Data loss if local files are corrupted. No apparent backup strategy.

## 3) Security Architecture (STRIDE Analysis)

### 🔴 High Risks
1.  **Tampering:**
    -   *Threat:* Local executable can be easily reverse-engineered (start with `dnSpy`).
    -   *Mitigation:* Obfuscation (Dotfuscator) if IP protection is needed.

2.  **Elevation of Privilege:**
    -   *Threat:* If this app controls hardware (Alarm Control) and runs with Admin privileges, a vulnerability could compromise the host OS.
    -   *Mitigation:* Apply "Least Privilege". Ensure app runs as Standard User.

## 4) Reliability & Observability
- **Monitoring:** None.
- **Logging:** Likely none or local text mesh.
- **Recommendation:** Implement `System.Diagnostics.Trace` or a simple file logger for errors.

## 5) Recommendations
- **Modernization:** Consider migrating to C# / .NET 6+ / WPF or MAUI if long-term maintenance is required.
- **Code Quality:** Extract business logic from `FrmMain.vb` into a separate Class Library (`.dll`) to enable Unit Testing.
