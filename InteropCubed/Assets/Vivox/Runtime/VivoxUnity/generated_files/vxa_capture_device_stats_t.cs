//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class vxa_capture_device_stats_t : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal vxa_capture_device_stats_t(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(vxa_capture_device_stats_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~vxa_capture_device_stats_t() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          VivoxCoreInstancePINVOKE.delete_vxa_capture_device_stats_t(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public int buffer_underrun_count {
    set {
      VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_buffer_underrun_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_buffer_underrun_count_get(swigCPtr);
      return ret;
    } 
  }

  public int buffer_overrun_count {
    set {
      VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_buffer_overrun_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_buffer_overrun_count_get(swigCPtr);
      return ret;
    } 
  }

  public int other_error_count {
    set {
      VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_other_error_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_other_error_count_get(swigCPtr);
      return ret;
    } 
  }

  public int audio_queue_read_count {
    set {
      VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_audio_queue_read_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_audio_queue_read_count_get(swigCPtr);
      return ret;
    } 
  }

  public int audio_queue_write_count {
    set {
      VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_audio_queue_write_count_set(swigCPtr, value);
    } 
    get {
      int ret = VivoxCoreInstancePINVOKE.vxa_capture_device_stats_t_audio_queue_write_count_get(swigCPtr);
      return ret;
    } 
  }

  public vxa_capture_device_stats_t() : this(VivoxCoreInstancePINVOKE.new_vxa_capture_device_stats_t(), true) {
  }

}
