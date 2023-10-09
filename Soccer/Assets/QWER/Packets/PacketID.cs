namespace Packets
{
    public enum PacketID
    {
        C_LogInPacket,      // 클라 로그인
        S_LogInPacket,      // 서버 로그인
        C_RoomEnterPacket,  // 클라 방입장
        S_RoomEnterPacket,  // 서버 방입장
        S_PlayerJoinPacket, // 서버 플레이어 입장
        S_MovePacket,       // 서버 움직임
        C_MovePacket        // 클라 움직임
    }
}