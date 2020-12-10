/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMBIENCE = 278617630U;
        static const AkUniqueID PLAY_DEATHMUSIC = 477908357U;
        static const AkUniqueID PLAY_DEATHTRANSITION = 2295672933U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_LADDERCLIMB = 2071442557U;
        static const AkUniqueID PLAY_SINES = 647636032U;
        static const AkUniqueID STOP_SINES = 4065681590U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace CHASE
        {
            static const AkUniqueID GROUP = 417490929U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace STATE
        } // namespace CHASE

        namespace LOCOMOTION
        {
            static const AkUniqueID GROUP = 556887514U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID RUNNING = 3863236874U;
                static const AkUniqueID WALKING = 340271938U;
            } // namespace STATE
        } // namespace LOCOMOTION

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID CORRECT_SINE = 1694191731U;
        static const AkUniqueID CURRENT_SINE = 602825232U;
        static const AkUniqueID TENSION = 1571361561U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID SUBMARINE = 232782671U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
