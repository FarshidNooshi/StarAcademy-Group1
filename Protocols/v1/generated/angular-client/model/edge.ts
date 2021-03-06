/**
 * PolarisApi
 * This is the api for Polaris Data Analysis Project on  [PolarisGithub](https://github.com/Star-Academy/StarAcademy-Group2/) 
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

/**
 * Edge of the graph
 */
export interface Edge { 
    /**
     * Unique id of the edge
     */
    id?: string;
    /**
     * Unique id of the source node
     */
    source?: string;
    /**
     * Unique id of the target node
     */
    target?: string;
    /**
     * Data of the entity that is set on the edge
     */
    data?: any;
}