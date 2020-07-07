package net.ponderingprogrammer.map2d.gen;

import org.junit.jupiter.api.Test;
import org.locationtech.jts.geom.Envelope;

import static org.junit.jupiter.api.Assertions.*;

class EnvelopeExTest {

    @Test
    void createSubEnvelope() {
        var superEnv = new Envelope(0, 100, 0, 200);
        var topHalf = EnvelopeEx.createSubEnvelope(superEnv, Alignment.TOP, 1f, 0.5f);
        assertEquals(100, topHalf.getWidth());
        assertEquals(100, topHalf.getHeight());
        assertEquals(0, topHalf.getMinX());
        assertEquals(0, topHalf.getMinY());
        var botRightQuarter = EnvelopeEx.createSubEnvelope(superEnv, Alignment.BOTTOM_RIGHT, 0.5f, 0.5f);
        assertEquals(50, botRightQuarter.getWidth());
        assertEquals(100, botRightQuarter.getHeight());
        assertEquals(50, botRightQuarter.getMinX());
        assertEquals(100, botRightQuarter.getMinY());
    }
}