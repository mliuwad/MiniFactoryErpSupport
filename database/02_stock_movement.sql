-- =========================================
-- FACTORY ERP SUPPORT SYSTEM
-- STOCK MOVEMENT PROCEDURE
-- Oracle Database
-- =========================================

CREATE OR REPLACE PROCEDURE SP_STOCK_MOVEMENT (
    P_MATERIAL_ID   IN NUMBER,
    P_WAREHOUSE_ID  IN NUMBER,
    P_TYPE          IN VARCHAR2,
    P_QUANTITY      IN NUMBER,
    P_REFERENCE_NO  IN VARCHAR2 DEFAULT NULL,
    P_NOTE          IN VARCHAR2 DEFAULT NULL
)
AS
    V_CURRENT_QTY NUMBER(12,2);
    V_NEW_QTY     NUMBER(12,2);
    V_TYPE        VARCHAR2(3);
BEGIN
    -- 1. Normalize transaction type
    V_TYPE := UPPER(TRIM(P_TYPE));

    -- 2. Validate transaction type
    IF V_TYPE IS NULL OR V_TYPE NOT IN ('IN', 'OUT') THEN
        RAISE_APPLICATION_ERROR(
            -20001,
            'Transaction type must be IN or OUT'
        );
    END IF;

    -- 3. Validate quantity
    IF P_QUANTITY IS NULL OR P_QUANTITY <= 0 THEN
        RAISE_APPLICATION_ERROR(
            -20002,
            'Quantity must be greater than 0'
        );
    END IF;

    -- 4. Lock current stock balance
    SELECT QUANTITY
    INTO V_CURRENT_QTY
    FROM STOCK_BALANCES
    WHERE MATERIAL_ID = P_MATERIAL_ID
      AND WAREHOUSE_ID = P_WAREHOUSE_ID
    FOR UPDATE;

    -- 5. Calculate new stock balance
    IF V_TYPE = 'IN' THEN

        V_NEW_QTY := V_CURRENT_QTY + P_QUANTITY;

    ELSE

        IF V_CURRENT_QTY < P_QUANTITY THEN
            RAISE_APPLICATION_ERROR(
                -20003,
                'Insufficient stock'
            );
        END IF;

        V_NEW_QTY := V_CURRENT_QTY - P_QUANTITY;

    END IF;

    -- 6. Update stock balance
    UPDATE STOCK_BALANCES
    SET QUANTITY = V_NEW_QTY
    WHERE MATERIAL_ID = P_MATERIAL_ID
      AND WAREHOUSE_ID = P_WAREHOUSE_ID;

    -- 7. Record stock transaction
    INSERT INTO STOCK_TRANSACTIONS (
        MATERIAL_ID,
        WAREHOUSE_ID,
        TRANSACTION_TYPE,
        QUANTITY,
        REFERENCE_NO,
        NOTE
    )
    VALUES (
        P_MATERIAL_ID,
        P_WAREHOUSE_ID,
        V_TYPE,
        P_QUANTITY,
        P_REFERENCE_NO,
        P_NOTE
    );

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(
            -20004,
            'Stock balance not initialized for this material and warehouse'
        );
END;
/
