namespace MFW.Core
{
    public enum FECCAction
    {
        UNKNOWN = 0
        ,START			/**< Initiates a start action for FECC. */
        ,CONTINUE			/**< Initiates a continue action for FECC; used between the start and stop actions. */
        ,STOP				/**< Initiates a stop action for FECC corresponding to the start action.*/
        ,MAX
    }
}
