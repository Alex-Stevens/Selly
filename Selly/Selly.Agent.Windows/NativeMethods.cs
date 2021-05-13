using System;
using System.Runtime.InteropServices;

namespace Selly.Agent.Windows
{
    public struct SEC_WINNT_AUTH_IDENTITY_W
    {
        /// unsigned short*
        public IntPtr User;

        /// unsigned int
        public uint UserLength;

        /// unsigned short*
        public IntPtr Domain;

        /// unsigned int
        public uint DomainLength;

        /// unsigned short*
        public IntPtr Password;

        /// unsigned int
        public uint PasswordLength;

        /// unsigned int
        public uint Flags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GUID
    {
        /// unsigned int
        public uint Data1;

        /// unsigned short
        public ushort Data2;

        /// unsigned short
        public ushort Data3;

        /// unsigned char[8]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Data4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWPM_DISPLAY_DATA0_
    {
        /// wchar_t*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string name;

        /// wchar_t*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string description;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_BYTE_BLOB_
    {
        /// UINT32->int
        public int size;

        /// UINT8*
        [MarshalAs(UnmanagedType.LPStr)]
        public string data;
    }

    public enum FWP_DIRECTION_
    {
        /// FWP_DIRECTION_OUTBOUND -> 0
        FWP_DIRECTION_OUTBOUND = 0,

        /// FWP_DIRECTION_INBOUND -> (FWP_DIRECTION_OUTBOUND+1)
        FWP_DIRECTION_INBOUND = (FWP_DIRECTION_OUTBOUND + 1),

        /// FWP_DIRECTION_MAX -> (FWP_DIRECTION_INBOUND+1)
        FWP_DIRECTION_MAX = (FWP_DIRECTION_INBOUND + 1),
    }

    public enum FWP_IP_VERSION_
    {
        /// FWP_IP_VERSION_V4 -> 0
        FWP_IP_VERSION_V4 = 0,

        /// FWP_IP_VERSION_V6 -> (FWP_IP_VERSION_V4+1)
        FWP_IP_VERSION_V6 = (FWP_IP_VERSION_V4 + 1),

        /// FWP_IP_VERSION_NONE -> (FWP_IP_VERSION_V6+1)
        FWP_IP_VERSION_NONE = (FWP_IP_VERSION_V6 + 1),

        /// FWP_IP_VERSION_MAX -> (FWP_IP_VERSION_NONE+1)
        FWP_IP_VERSION_MAX = (FWP_IP_VERSION_NONE + 1),
    }

    public enum FWP_NE_FAMILY_
    {
        /// FWP_AF_INET -> FWP_IP_VERSION_V4
        FWP_AF_INET = FWP_IP_VERSION_.FWP_IP_VERSION_V4,

        /// FWP_AF_INET6 -> FWP_IP_VERSION_V6
        FWP_AF_INET6 = FWP_IP_VERSION_.FWP_IP_VERSION_V6,

        /// FWP_AF_ETHER -> FWP_IP_VERSION_NONE
        FWP_AF_ETHER = FWP_IP_VERSION_.FWP_IP_VERSION_NONE,

        /// FWP_AF_NONE -> (FWP_AF_ETHER+1)
        FWP_AF_NONE = (FWP_NE_FAMILY_.FWP_AF_ETHER + 1),
    }

    public enum FWP_ETHER_ENCAP_METHOD_
    {
        /// FWP_ETHER_ENCAP_METHOD_ETHER_V2 -> 0
        FWP_ETHER_ENCAP_METHOD_ETHER_V2 = 0,

        /// FWP_ETHER_ENCAP_METHOD_SNAP -> 1
        FWP_ETHER_ENCAP_METHOD_SNAP = 1,

        /// FWP_ETHER_ENCAP_METHOD_SNAP_W_OUI_ZERO -> 3
        FWP_ETHER_ENCAP_METHOD_SNAP_W_OUI_ZERO = 3,
    }

    public enum FWP_DATA_TYPE_
    {
        /// FWP_EMPTY -> 0
        FWP_EMPTY = 0,

        /// FWP_UINT8 -> (FWP_EMPTY+1)
        FWP_UINT8 = (FWP_EMPTY + 1),

        /// FWP_UINT16 -> (FWP_UINT8+1)
        FWP_UINT16 = (FWP_UINT8 + 1),

        /// FWP_UINT32 -> (FWP_UINT16+1)
        FWP_UINT32 = (FWP_UINT16 + 1),

        /// FWP_UINT64 -> (FWP_UINT32+1)
        FWP_UINT64 = (FWP_UINT32 + 1),

        /// FWP_INT8 -> (FWP_UINT64+1)
        FWP_INT8 = (FWP_UINT64 + 1),

        /// FWP_INT16 -> (FWP_INT8+1)
        FWP_INT16 = (FWP_INT8 + 1),

        /// FWP_INT32 -> (FWP_INT16+1)
        FWP_INT32 = (FWP_INT16 + 1),

        /// FWP_INT64 -> (FWP_INT32+1)
        FWP_INT64 = (FWP_INT32 + 1),

        /// FWP_FLOAT -> (FWP_INT64+1)
        FWP_FLOAT = (FWP_INT64 + 1),

        /// FWP_DOUBLE -> (FWP_FLOAT+1)
        FWP_DOUBLE = (FWP_FLOAT + 1),

        /// FWP_BYTE_ARRAY16_TYPE -> (FWP_DOUBLE+1)
        FWP_BYTE_ARRAY16_TYPE = (FWP_DOUBLE + 1),

        /// FWP_BYTE_BLOB_TYPE -> (FWP_BYTE_ARRAY16_TYPE+1)
        FWP_BYTE_BLOB_TYPE = (FWP_BYTE_ARRAY16_TYPE + 1),

        /// FWP_SID -> (FWP_BYTE_BLOB_TYPE+1)
        FWP_SID = (FWP_BYTE_BLOB_TYPE + 1),

        /// FWP_SECURITY_DESCRIPTOR_TYPE -> (FWP_SID+1)
        FWP_SECURITY_DESCRIPTOR_TYPE = (FWP_SID + 1),

        /// FWP_TOKEN_INFORMATION_TYPE -> (FWP_SECURITY_DESCRIPTOR_TYPE+1)
        FWP_TOKEN_INFORMATION_TYPE = (FWP_SECURITY_DESCRIPTOR_TYPE + 1),

        /// FWP_TOKEN_ACCESS_INFORMATION_TYPE -> (FWP_TOKEN_INFORMATION_TYPE+1)
        FWP_TOKEN_ACCESS_INFORMATION_TYPE = (FWP_TOKEN_INFORMATION_TYPE + 1),

        /// FWP_UNICODE_STRING_TYPE -> (FWP_TOKEN_ACCESS_INFORMATION_TYPE+1)
        FWP_UNICODE_STRING_TYPE = (FWP_TOKEN_ACCESS_INFORMATION_TYPE + 1),

        /// FWP_BYTE_ARRAY6_TYPE -> (FWP_UNICODE_STRING_TYPE+1)
        FWP_BYTE_ARRAY6_TYPE = (FWP_UNICODE_STRING_TYPE + 1),

        /// FWP_BITMAP_INDEX_TYPE -> (FWP_BYTE_ARRAY6_TYPE+1)
        FWP_BITMAP_INDEX_TYPE = (FWP_BYTE_ARRAY6_TYPE + 1),

        /// FWP_BITMAP_ARRAY64_TYPE -> (FWP_BITMAP_INDEX_TYPE+1)
        FWP_BITMAP_ARRAY64_TYPE = (FWP_BITMAP_INDEX_TYPE + 1),

        /// FWP_SINGLE_DATA_TYPE_MAX -> 0xff
        FWP_SINGLE_DATA_TYPE_MAX = 255,

        /// FWP_V4_ADDR_MASK -> (FWP_SINGLE_DATA_TYPE_MAX+1)
        FWP_V4_ADDR_MASK = (FWP_SINGLE_DATA_TYPE_MAX + 1),

        /// FWP_V6_ADDR_MASK -> (FWP_V4_ADDR_MASK+1)
        FWP_V6_ADDR_MASK = (FWP_V4_ADDR_MASK + 1),

        /// FWP_RANGE_TYPE -> (FWP_V6_ADDR_MASK+1)
        FWP_RANGE_TYPE = (FWP_V6_ADDR_MASK + 1),

        /// FWP_DATA_TYPE_MAX -> (FWP_RANGE_TYPE+1)
        FWP_DATA_TYPE_MAX = (FWP_RANGE_TYPE + 1),
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FWP_BITMAP_ARRAY64_
    {
        /// UINT8[8]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string bitmapArray64;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FWP_BYTE_ARRAY6_
    {
        /// UINT8[6]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string byteArray6;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FWP_BYTE_ARRAY16_
    {
        /// UINT8[16]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string byteArray16;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_TOKEN_INFORMATION_
    {
        /// ULONG->int
        public int sidCount;

        /// PSID_AND_S->_SID_AND_S*
        public IntPtr sids;

        /// ULONG->int
        public int restrictedSidCount;

        /// PSID_AND_S->_SID_AND_S*
        public IntPtr restrictedSids;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Anonymous_8e3b2402_32d6_4547_b339_2f85254c97a0
    {
        /// UINT8->char
        [FieldOffset(0)]
        public byte uint8;

        /// UINT16->short
        [FieldOffset(0)]
        public short uint16;

        /// UINT32->int
        [FieldOffset(0)]
        public int uint32;

        /// UINT64*
        [FieldOffset(0)]
        public IntPtr uint64;

        /// INT8->char
        [FieldOffset(0)]
        public byte int8;

        /// INT16->short
        [FieldOffset(0)]
        public short int16;

        /// INT32->int
        [FieldOffset(0)]
        public int int32;

        /// INT64*
        [FieldOffset(0)]
        public IntPtr int64;

        /// float
        [FieldOffset(0)]
        public float float32;

        /// double*
        [FieldOffset(0)]
        public IntPtr double64;

        /// FWP_BYTE_ARRAY16*
        [FieldOffset(0)]
        public IntPtr byteArray16;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr byteBlob;

        /// SID*
        [FieldOffset(0)]
        public IntPtr sid;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr sd;

        /// FWP_TOKEN_INFORMATION*
        [FieldOffset(0)]
        public IntPtr tokenInformation;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr tokenAccessInformation;

        /// LPWSTR->WCHAR*
        [FieldOffset(0)]
        public IntPtr unicodeString;

        /// FWP_BYTE_ARRAY6*
        [FieldOffset(0)]
        public IntPtr byteArray6;

        /// FWP_BITMAP_ARRAY64*
        [FieldOffset(0)]
        public IntPtr bitmapArray64;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_VALUE0_
    {
        /// FWP_DATA_TYPE->FWP_DATA_TYPE_
        public FWP_DATA_TYPE_ type;

        /// Anonymous_8e3b2402_32d6_4547_b339_2f85254c97a0
        public Anonymous_8e3b2402_32d6_4547_b339_2f85254c97a0 Union1;
    }

    public enum FWP_MATCH_TYPE_
    {
        /// FWP_MATCH_EQUAL -> 0
        FWP_MATCH_EQUAL = 0,

        /// FWP_MATCH_GREATER -> (FWP_MATCH_EQUAL+1)
        FWP_MATCH_GREATER = (FWP_MATCH_EQUAL + 1),

        /// FWP_MATCH_LESS -> (FWP_MATCH_GREATER+1)
        FWP_MATCH_LESS = (FWP_MATCH_GREATER + 1),

        /// FWP_MATCH_GREATER_OR_EQUAL -> (FWP_MATCH_LESS+1)
        FWP_MATCH_GREATER_OR_EQUAL = (FWP_MATCH_LESS + 1),

        /// FWP_MATCH_LESS_OR_EQUAL -> (FWP_MATCH_GREATER_OR_EQUAL+1)
        FWP_MATCH_LESS_OR_EQUAL = (FWP_MATCH_GREATER_OR_EQUAL + 1),

        /// FWP_MATCH_RANGE -> (FWP_MATCH_LESS_OR_EQUAL+1)
        FWP_MATCH_RANGE = (FWP_MATCH_LESS_OR_EQUAL + 1),

        /// FWP_MATCH_FLAGS_ALL_SET -> (FWP_MATCH_RANGE+1)
        FWP_MATCH_FLAGS_ALL_SET = (FWP_MATCH_RANGE + 1),

        /// FWP_MATCH_FLAGS_ANY_SET -> (FWP_MATCH_FLAGS_ALL_SET+1)
        FWP_MATCH_FLAGS_ANY_SET = (FWP_MATCH_FLAGS_ALL_SET + 1),

        /// FWP_MATCH_FLAGS_NONE_SET -> (FWP_MATCH_FLAGS_ANY_SET+1)
        FWP_MATCH_FLAGS_NONE_SET = (FWP_MATCH_FLAGS_ANY_SET + 1),

        /// FWP_MATCH_EQUAL_CASE_INSENSITIVE -> (FWP_MATCH_FLAGS_NONE_SET+1)
        FWP_MATCH_EQUAL_CASE_INSENSITIVE = (FWP_MATCH_FLAGS_NONE_SET + 1),

        /// FWP_MATCH_NOT_EQUAL -> (FWP_MATCH_EQUAL_CASE_INSENSITIVE+1)
        FWP_MATCH_NOT_EQUAL = (FWP_MATCH_EQUAL_CASE_INSENSITIVE + 1),

        /// FWP_MATCH_PREFIX -> (FWP_MATCH_NOT_EQUAL+1)
        FWP_MATCH_PREFIX = (FWP_MATCH_NOT_EQUAL + 1),

        /// FWP_MATCH_NOT_PREFIX -> (FWP_MATCH_PREFIX+1)
        FWP_MATCH_NOT_PREFIX = (FWP_MATCH_PREFIX + 1),

        /// FWP_MATCH_TYPE_MAX -> (FWP_MATCH_NOT_PREFIX+1)
        FWP_MATCH_TYPE_MAX = (FWP_MATCH_NOT_PREFIX + 1),
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_V4_ADDR_AND_MASK_
    {
        /// UINT32->int
        public int addr;

        /// UINT32->int
        public int mask;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FWP_V6_ADDR_AND_MASK_
    {
        /// UINT8[16]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string addr;

        /// UINT8->char
        public byte prefixLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_RANGE0_
    {
        /// FWP_VALUE0->FWP_VALUE0_
        public FWP_VALUE0_ valueLow;

        /// FWP_VALUE0->FWP_VALUE0_
        public FWP_VALUE0_ valueHigh;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Anonymous_805a26b0_66f5_4c50_bc36_b71a785ca4ea
    {
        /// UINT8->char
        [FieldOffset(0)]
        public byte uint8;

        /// UINT16->short
        [FieldOffset(0)]
        public short uint16;

        /// UINT32->int
        [FieldOffset(0)]
        public int uint32;

        /// UINT64*
        [FieldOffset(0)]
        public IntPtr uint64;

        /// INT8->char
        [FieldOffset(0)]
        public byte int8;

        /// INT16->short
        [FieldOffset(0)]
        public short int16;

        /// INT32->int
        [FieldOffset(0)]
        public int int32;

        /// INT64*
        [FieldOffset(0)]
        public IntPtr int64;

        /// float
        [FieldOffset(0)]
        public float float32;

        /// double*
        [FieldOffset(0)]
        public IntPtr double64;

        /// FWP_BYTE_ARRAY16*
        [FieldOffset(0)]
        public IntPtr byteArray16;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr byteBlob;

        /// SID*
        [FieldOffset(0)]
        public IntPtr sid;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr sd;

        /// FWP_TOKEN_INFORMATION*
        [FieldOffset(0)]
        public IntPtr tokenInformation;

        /// FWP_BYTE_BLOB*
        [FieldOffset(0)]
        public IntPtr tokenAccessInformation;

        /// LPWSTR->WCHAR*
        [FieldOffset(0)]
        public IntPtr unicodeString;

        /// FWP_BYTE_ARRAY6*
        [FieldOffset(0)]
        public IntPtr byteArray6;

        /// FWP_BITMAP_ARRAY64*
        [FieldOffset(0)]
        public IntPtr bitmapArray64;

        /// FWP_V4_ADDR_AND_MASK*
        [FieldOffset(0)]
        public IntPtr v4AddrMask;

        /// FWP_V6_ADDR_AND_MASK*
        [FieldOffset(0)]
        public IntPtr v6AddrMask;

        /// FWP_RANGE0*
        [FieldOffset(0)]
        public IntPtr rangeValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWP_CONDITION_VALUE0_
    {
        /// FWP_DATA_TYPE->FWP_DATA_TYPE_
        public FWP_DATA_TYPE_ type;

        /// Anonymous_805a26b0_66f5_4c50_bc36_b71a785ca4ea
        public Anonymous_805a26b0_66f5_4c50_bc36_b71a785ca4ea Union1;
    }

    public enum FWP_CLASSIFY_OPTION_TYPE_
    {
        /// FWP_CLASSIFY_OPTION_MULTICAST_STATE -> 0
        FWP_CLASSIFY_OPTION_MULTICAST_STATE = 0,

        /// FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING -> (FWP_CLASSIFY_OPTION_MULTICAST_STATE+1)
        FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING = (FWP_CLASSIFY_OPTION_MULTICAST_STATE + 1),

        /// FWP_CLASSIFY_OPTION_UNICAST_LIFETIME -> (FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING+1)
        FWP_CLASSIFY_OPTION_UNICAST_LIFETIME = (FWP_CLASSIFY_OPTION_LOOSE_SOURCE_MAPPING + 1),

        /// FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME -> (FWP_CLASSIFY_OPTION_UNICAST_LIFETIME+1)
        FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME = (FWP_CLASSIFY_OPTION_UNICAST_LIFETIME + 1),

        /// FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS -> (FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME+1)
        FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS = (FWP_CLASSIFY_OPTION_MCAST_BCAST_LIFETIME + 1),

        /// FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY -> (FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS+1)
        FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY = (FWP_CLASSIFY_OPTION_SECURE_SOCKET_SECURITY_FLAGS + 1),

        /// FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY -> (FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY+1)
        FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY = (FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_MM_POLICY_KEY + 1),

        /// FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING -> (FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY+1)
        FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING = (FWP_CLASSIFY_OPTION_SECURE_SOCKET_AUTHIP_QM_POLICY_KEY + 1),

        /// FWP_CLASSIFY_OPTION_MAX -> (FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING+1)
        FWP_CLASSIFY_OPTION_MAX = (FWP_CLASSIFY_OPTION_LOCAL_ONLY_MAPPING + 1),
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWPM_FILTER_CONDITION0_
    {
        /// GUID->_GUID
        public GUID fieldKey;

        /// FWP_MATCH_TYPE->FWP_MATCH_TYPE_
        public FWP_MATCH_TYPE_ matchType;

        /// FWP_CONDITION_VALUE0->FWP_CONDITION_VALUE0_
        public FWP_CONDITION_VALUE0_ conditionValue;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Anonymous_882e0235_d3a3_490f_a158_602f680503f8
    {
        /// GUID->_GUID
        [FieldOffset(0)]
        public GUID filterType;

        /// GUID->_GUID
        [FieldOffset(0)]
        public GUID calloutKey;

        ///// UINT8->char
        //[FieldOffset(0)]
        //public byte bitmapIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWPM_ACTION0_
    {
        /// FWP_ACTION_TYPE->UINT32->int
        public int type;

        /// Anonymous_882e0235_d3a3_490f_a158_602f680503f8
        public Anonymous_882e0235_d3a3_490f_a158_602f680503f8 Union1;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Anonymous_54331063_b8b8_4dc3_a14f_eccc8d43f7d5
    {
        ///// UINT64->__int64
        //[FieldOffset(0)]
        //public long rawContext;

        /// GUID->_GUID
        [FieldOffset(0)]
        public GUID providerContextKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWPM_FILTER0_
    {
        /// GUID->_GUID
        public GUID filterKey;

        /// FWPM_DISPLAY_DATA0->FWPM_DISPLAY_DATA0_
        public FWPM_DISPLAY_DATA0_ displayData;

        /// UINT32->int
        public int flags;

        /// GUID*
        public IntPtr providerKey;

        /// FWP_BYTE_BLOB->FWP_BYTE_BLOB_
        public FWP_BYTE_BLOB_ providerData;

        /// GUID->_GUID
        public Guid layerKey;

        /// GUID->_GUID
        public GUID subLayerKey;

        /// FWP_VALUE0->FWP_VALUE0_
        public FWP_VALUE0_ weight;

        /// UINT32->int
        public int numFilterConditions;

        /// FWPM_FILTER_CONDITION0*
        public IntPtr filterCondition;

        /// FWPM_ACTION0->FWPM_ACTION0_
        public FWPM_ACTION0_ action;

        /// Anonymous_54331063_b8b8_4dc3_a14f_eccc8d43f7d5
        public Anonymous_54331063_b8b8_4dc3_a14f_eccc8d43f7d5 Union1;

        /// GUID*
        public IntPtr reserved;

        /// UINT64->__int64
        public long filterId;

        /// FWP_VALUE0->FWP_VALUE0_
        public FWP_VALUE0_ effectiveWeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FWPM_SESSION0_
    {
        /// GUID->_GUID
        public GUID sessionKey;

        /// FWPM_DISPLAY_DATA0->FWPM_DISPLAY_DATA0_
        public FWPM_DISPLAY_DATA0_ displayData;

        /// UINT32->int
        public int flags;

        /// UINT32->int
        public int txnWaitTimeoutInMSec;

        /// DWORD->int
        public int processId;

        /// SID*
        public IntPtr sid;

        /// wchar_t*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string username;

        /// BOOL->int
        public int kernelMode;
    }

    public partial class NativeMethods
    {
        [DllImport("Fwpuclnt.dll", EntryPoint = "FwpmEngineOpen0")]
        public static extern uint FwpmEngineOpen0([In()] [MarshalAs(UnmanagedType.LPWStr)] string serverName,
            uint authnService, [In()] IntPtr authIdentity, [In()] IntPtr session, ref IntPtr engineHandle);

        /// Return Type: DWORD->int
        ///engineHandle: HANDLE->void*
        ///id: UINT64->__int64
        ///filter: FWPM_FILTER0**
        [DllImport("Fwpuclnt.dll", EntryPoint = "FwpmFilterGetById0")]
        public static extern uint FwpmFilterGetById0(IntPtr engineHandle, long id, ref IntPtr filter);

        /// Return Type: void
        ///p: void**
        [DllImport("Fwpuclnt.dll", EntryPoint = "FwpmFreeMemory0")]
        public static extern void FwpmFreeMemory0(ref IntPtr p);

        /// Return Type: DWORD->int
        ///engineHandle: HANDLE->void*
        [DllImport("Fwpuclnt.dll", EntryPoint = "FwpmEngineClose0")]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern int FwpmEngineClose0(IntPtr engineHandle);
    }
}
